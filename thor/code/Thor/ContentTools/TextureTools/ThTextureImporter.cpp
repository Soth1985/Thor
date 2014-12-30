#include <Thor/ContentTools/TextureTools/ThTextureImporter.h>
#include <Thor/ContentTools/TextureTools/ThTextureToolsUtils.h>
#include <Thor/ContentTools/ContentPipeline/ThContentPipeline.h>
#include <tuple>
#include <tbb/flow_graph.h>
#include <tbb/concurrent_unordered_map.h>
#include <tbb/concurrent_unordered_set.h>
#include <tbb/concurrent_vector.h>

using namespace Thor::ContentToolsProtocol;
using namespace DirectX;
using namespace tbb::flow;

namespace Thor
{

THOR_REG_TYPE(ThTextureImporter, THOR_TYPELIST_1(ThiContentImporter));

struct ImageProcessingGraph;

struct eProcessingNodePort
{
	enum Val
	{
		Failure,
		Success
	};
};

struct InputType
{
	InputType()
	{

	}

	InputType(const ThWideString& inputPath, const ThWideString& outputPath, const ThString& hash, const TheTextureImportOptionsPtr options, ThSize tag, ThSize index, ThSize numItems, eTextureArrayType::Val arrayType = eTextureArrayType::UNKNOWN)
		:
	m_InputPath(inputPath),
	m_Options(options),
	m_Tag(tag),
	m_Index(index),
	m_NumItems(numItems),
	m_Hash(hash),
	m_OutputPath(outputPath),
	m_ArrayType(arrayType)
	{
		m_Failed = false;
	}

	ThString m_Hash;
	ThWideString m_InputPath;
	ThWideString m_OutputPath;
	TheTextureImportOptionsPtr m_Options;
	ThSize m_Tag;
	ThSize m_Index;
	ThSize m_NumItems;
	eTextureArrayType::Val m_ArrayType;
	ThBool m_Failed;
};

struct ProcessorInput : public InputType
{
	ProcessorInput()
	{

	}

	ProcessorInput(const InputType& input, ScratchImage* image)
		:
	InputType(input),
	m_Image(image)
	{

	}

	ProcessorInput(const ProcessorInput& input, ScratchImage* image)
		:
	InputType(input.m_InputPath, input.m_OutputPath, input.m_Hash, input.m_Options, input.m_Tag, input.m_Index, input.m_NumItems, input.m_ArrayType),
	m_Image(image)
	{
		if (image)
			m_Failed = false;
		else
			m_Failed = true;
	}

	ScratchImage* m_Image;
};

template <class InputT>
void ProcessResult(ImageProcessingGraph* g, ScratchImage* result, const InputT& input, const ThWideString& stageName)
{
	if (result)
	{
		THOR_INF_W("Stage [%ls] has succeeded for input texture %ls")(textureToolsLogTag, stageName.c_str(), input.m_InputPath.c_str());
	} 
	else
	{
		THOR_ERR_W("Stage [%ls] has failed for input texture %ls")(textureToolsLogTag, stageName.c_str(), input.m_InputPath.c_str());
		g->AddFailedTag(input.m_Tag);
	}
}

struct ImageProcessingGraph
{
	ImageProcessingGraph(ThContentPipeline* pipeline, graph& g)
		:
	m_Graph(&g),
	m_Pipeline(pipeline)
	{
	}

	virtual ~ImageProcessingGraph()
	{
		delete m_Source;
		delete m_Limiter;
		delete m_Loader;
		delete m_Decompress;
		delete m_FlipRotate;
		delete m_Resize;
		delete m_ConvertFormat;
		delete m_PremultiplyAlpha;
		delete m_Compress;
		delete m_GenerateMipmaps;
		delete m_Output;
	}

	virtual void InitNodes(ThSize maxImagesAtOnce)
	{
		m_Source = new SourceNode(*m_Graph);

		m_Limiter = new LimiterNode(*m_Graph, maxImagesAtOnce);

		m_Loader = new ImageLoaderNode(*m_Graph, unlimited, 
			[this] (const InputType &input)->ProcessorInput
		{
			ScratchImage* result = 0;

			if (!IsTagFailed(input.m_Tag))
				result = LoadImageStep(input.m_InputPath, input.m_Options);


			if (result && input.m_NumItems > 1)
			{
				const TexMetadata& info = result->GetMetadata();

				if ( info.arraySize > 1
					|| info.depth > 1
					|| info.mipLevels > 1
					|| info.IsCubemap() )
				{
					THOR_ERR_W("Can't assemble complex surfaces, file = %ls")(textureToolsLogTag, input.m_InputPath.c_str());
					delete result;
					result = 0;
				}
			}

			ProcessResult(this, result, input, L"Load Image");

			return ProcessorInput(input, result);
		}
		);

		m_Decompress = new ImageProcessorNode(*m_Graph, unlimited, 
			[this] (const ProcessorInput &input)->ProcessorInput
		{
			ScratchImage* result = 0;

			if (!IsTagFailed(input.m_Tag))
				result = DecompressStep(input.m_Image);

			ProcessResult(this, result, input, L"Decompress");

			return ProcessorInput(input, result);
		}
		);

		m_FlipRotate = new ImageProcessorNode(*m_Graph, unlimited, 
			[this] (const ProcessorInput &input)->ProcessorInput
		{
			ScratchImage* result = 0;

			if (!IsTagFailed(input.m_Tag))
				result = FlipRotateStep(input.m_Image, input.m_Options);

			ProcessResult(this, result, input, L"FlipRotate");

			return ProcessorInput(input, result);
		}
		);

		m_Resize = new ImageProcessorNode(*m_Graph, unlimited, 
			[this] (const ProcessorInput &input)->ProcessorInput
		{
			ScratchImage* result = 0;

			if (!IsTagFailed(input.m_Tag))
				result = ResizeStep(input.m_Image, input.m_Options);

			ProcessResult(this, result, input, L"Resize");

			return ProcessorInput(input, result);
		}
		);

		m_ConvertFormat = new ImageProcessorNode(*m_Graph, unlimited, 
			[this] (const ProcessorInput &input)->ProcessorInput
		{
			ScratchImage* result = 0;

			if (!IsTagFailed(input.m_Tag))
				result = ConvertStep(input.m_Image, input.m_Options);

			ProcessResult(this, result, input, L"Convert Format");

			return ProcessorInput(input, result);
		}
		);

		m_PremultiplyAlpha = new ImageProcessorNode(*m_Graph, unlimited, 
			[this] (const ProcessorInput &input)->ProcessorInput
		{
			ScratchImage* result = 0;

			if (!IsTagFailed(input.m_Tag))
				result = PremultiplyAlphaStep(input.m_Image, input.m_Options);

			ProcessResult(this, result, input, L"Premultiply Alpha");

			return ProcessorInput(input, result);
		}
		);

		m_Compress = new ImageProcessorNode(*m_Graph, unlimited, 
			[this] (const ProcessorInput &input)->ProcessorInput
		{
			ScratchImage* result = 0;

			if (!IsTagFailed(input.m_Tag))
				result = CompressStep(input.m_Image, input.m_Options);

			ProcessResult(this, result, input, L"Compress");

			return ProcessorInput(input, result);
		}
		);

		m_GenerateMipmaps = new ImageProcessorNode(*m_Graph, unlimited, 
			[this] (const ProcessorInput &input)->ProcessorInput
		{
			ScratchImage* result = 0;

			if (!IsTagFailed(input.m_Tag))
				result = GenerateMipmapsStep(input.m_Image, input.m_Options);

			ProcessResult(this, result, input, L"Generate Mipmaps");

			return ProcessorInput(input, result);
		}
		);

		m_Output = new OutputNode(*m_Graph, unlimited,
			[this] (const ProcessorInput& input)->continue_msg
		{
			if (!input.m_Failed)
				OutputStep(input);

			delete input.m_Image;
			return continue_msg();
		}
		);
	}

	virtual void LinkNodes()
	{
		make_edge(*m_Source, *m_Limiter);
		make_edge(*m_Limiter, *m_Loader);
		make_edge(*m_Loader, *m_Decompress);
		make_edge(*m_Decompress, *m_FlipRotate);
		make_edge(*m_FlipRotate, *m_Resize);
		make_edge(*m_Resize, *m_ConvertFormat);
		make_edge(*m_ConvertFormat, *m_GenerateMipmaps);
		make_edge(*m_GenerateMipmaps, *m_PremultiplyAlpha);
		make_edge(*m_PremultiplyAlpha, *m_Compress);
		make_edge(*m_Compress, *m_Output);
		make_edge(*m_Output, m_Limiter->decrement);
	}

	ThU32 GetFilter(const TheTextureImportOptionsPtr& options)
	{
		return ThTextureToolsUtils::TranslateFilter(options->Filter.GetValueEnum());		
	}

	ThU32 GetFilterOpts(const TheTextureImportOptionsPtr& options)
	{
		ThU32 filterOpts = 0;

		if (options->TextureAddressMode.GetValueEnum() == eTextureAddressingMode::WRAP)
		{
			filterOpts |= TEX_FILTER_WRAP;
		}
		else if(options->TextureAddressMode.GetValueEnum() == eTextureAddressingMode::MIRROR)
		{
			filterOpts |= TEX_FILTER_MIRROR;
		}

		return filterOpts;
	}

	ThU32 GetSRGB(const TheTextureImportOptionsPtr& options)
	{
		ThU32 result = 0;

		if (options->InSRGB.GetValue())
			result |= TEX_FILTER_SRGB_IN;

		if (options->OutSRGB.GetValue())
			result |= TEX_FILTER_SRGB_OUT;

		if (options->InOutSRGB.GetValue())
			result |= TEX_FILTER_SRGB;
		
		return result;
	}

	ScratchImage* LoadImageStep(const ThWideString& path, const TheTextureImportOptionsPtr& options)
	{
		ThU32 ddsLoadFlags = 0;
		ThU32 dwFilter = ThTextureToolsUtils::TranslateFilter(options->Filter.GetValueEnum());

		ScratchImage* image = 0;

		if (options->UseDwordAlignmentDDS.GetValue())
			ddsLoadFlags |= eDDSLoadFlags::UseDwordAlignment;

		if (options->ExpandLuminanceDDS.GetValue())
			ddsLoadFlags |= eDDSLoadFlags::ExpandLuminance;

		if (options->UseTypelessUnormFormatDDS.GetValue())
			ddsLoadFlags |= eDDSLoadFlags::UseTypelessUnormFormat;

		if (options->UseTypelessFloatFormatDDS.GetValue())
			ddsLoadFlags |= eDDSLoadFlags::UseTypelessFloatFormat;

		if (!ThTextureToolsUtils::LoadImage(path, m_Pipeline, ddsLoadFlags, dwFilter, &image))
		{
			return 0;
		}

		return image;
	}
	
	ScratchImage* DecompressStep(ScratchImage* image)
	{
		ScratchImage* timage = 0;

		eImageProcessingResult::Val result = ThTextureToolsUtils::DecompressImage(image, &timage);

		if (result == eImageProcessingResult::Success)
		{
			delete image;
			return timage;
		}
		else if (result == eImageProcessingResult::Failure)
		{
			delete image;
			return 0;
		}

		return image;
	}
	
	ScratchImage* FlipRotateStep(ScratchImage* image, const TheTextureImportOptionsPtr& options)
	{
		ScratchImage* timage = 0;
		eImageProcessingResult::Val result = ThTextureToolsUtils::FlipRotateImage(image, options->VerticalFlip.GetValue(), options->HorizontalFlip.GetValue(), &timage);

		if (result == eImageProcessingResult::Success)
		{
			delete image;
			return timage;
		}
		else if (result == eImageProcessingResult::Failure)
		{
			delete image;
			return 0;
		}

		return image;
	}

	ScratchImage* ResizeStep(ScratchImage* image, const TheTextureImportOptionsPtr& options)
	{
		ScratchImage* timage = 0;

		const TexMetadata& info = image->GetMetadata();	

		ThSize twidth = ( !options->WidthOverride.GetValue() ) ? info.width : options->WidthOverride.GetValue();
		ThSize theight = ( !options->HeightOverrive.GetValue() ) ? info.height : options->HeightOverrive.GetValue();

		eImageProcessingResult::Val result = ThTextureToolsUtils::ResizeImage(image, twidth, theight, GetFilter(options) | GetFilterOpts(options), &timage);

		if (result == eImageProcessingResult::Success)
		{
			delete image;
			return timage;
		}
		else if (result == eImageProcessingResult::Failure)
		{
			delete image;
			return 0;
		}

		return image;
	}

	ScratchImage* ConvertStep(ScratchImage* image, const TheTextureImportOptionsPtr& options)
	{
		ScratchImage* timage = 0;
		const TexMetadata& info = image->GetMetadata();
		DXGI_FORMAT format = ThTextureToolsUtils::TranslateFormat(options->TargetFormat.GetValueEnum());
		DXGI_FORMAT tformat = ( format == DXGI_FORMAT_UNKNOWN ) ? info.format : format;
		eImageProcessingResult::Val result = ThTextureToolsUtils::ConvertImage(image, tformat, GetFilter(options) | GetFilterOpts(options) | GetSRGB(options), &timage);

		if (result == eImageProcessingResult::Success)
		{
			delete image;
			return timage;
		}
		else if (result == eImageProcessingResult::Failure)
		{
			delete image;
			return 0;
		}

		return image;
	}
	
	ScratchImage* GenerateMipmapsStep(ScratchImage* image, const TheTextureImportOptionsPtr& options)
	{
		ScratchImage* timage = 0;
		const TexMetadata& info = image->GetMetadata();

		ThSize mipLevels = options->MipLevelsOverride.GetValue();

		if (options->FileFormat.GetValueEnum() != eOutputFileFormat::DDS)
		{
			mipLevels = 1;
		}

		ThSize tMips = ( !mipLevels && info.mipLevels > 1 ) ? info.mipLevels : mipLevels;

		eImageProcessingResult::Val result = ThTextureToolsUtils::GenerateMipmaps(image, tMips, GetFilter(options) | GetFilterOpts(options), &timage);

		if (result == eImageProcessingResult::Success)
		{
			delete image;
			return timage;
		}
		else if (result == eImageProcessingResult::Failure)
		{
			delete image;
			return 0;
		}

		return image;
	}

	ScratchImage* PremultiplyAlphaStep(ScratchImage* image, const TheTextureImportOptionsPtr& options)
	{
		ScratchImage* timage = 0;

		if (options->PremultiplyAlpha.GetValue())
		{
			eImageProcessingResult::Val result = ThTextureToolsUtils::PremultiplyAlpha(image, &timage);

			if (result == eImageProcessingResult::Success)
			{
				delete image;
				return timage;
			}
			else if (result == eImageProcessingResult::Failure)
			{
				delete image;
				return 0;
			}
		}

		return image;
	}

	ScratchImage* CompressStep(ScratchImage* image, const TheTextureImportOptionsPtr& options)
	{
		ScratchImage* timage = 0;
		
		const TexMetadata& info = image->GetMetadata();
		DXGI_FORMAT format = ThTextureToolsUtils::TranslateFormat(options->TargetFormat.GetValueEnum());
		DXGI_FORMAT tformat = ( format == DXGI_FORMAT_UNKNOWN ) ? info.format : format;

		if (options->FileFormat.GetValueEnum() == eOutputFileFormat::DDS)
		{
			eImageProcessingResult::Val result = ThTextureToolsUtils::CompressImage(image, tformat, &timage);

			if (result == eImageProcessingResult::Success)
			{
				delete image;
				return timage;
			}
			else if (result == eImageProcessingResult::Failure)
			{
				delete image;
				return 0;
			}
		}

		return image;
	}

	void OutputStep(const ProcessorInput& input)
	{
		const ScratchImage* image = input.m_Image;
		TexMetadata info = image->GetMetadata();

		// --- Set alpha mode ----------------------------------------------------------
		if ( HasAlpha( info.format )
			&& info.format != DXGI_FORMAT_A8_UNORM )
		{
			if ( image->IsAlphaAllOpaque() )
			{
				info.SetAlphaMode(TEX_ALPHA_MODE_OPAQUE);
			}
			else if ( info.IsPMAlpha() )
			{
				// Aleady set TEX_ALPHA_MODE_PREMULTIPLIED
			}
			else if ( input.m_Options->SeparateAlpha.GetValue() )
			{
				info.SetAlphaMode(TEX_ALPHA_MODE_CUSTOM);
			}
			else
			{
				info.SetAlphaMode(TEX_ALPHA_MODE_STRAIGHT);
			}
		}
		else
		{
			info.miscFlags2 &= ~TEX_MISC2_ALPHA_MODE_MASK;
		}

		// --- Save result -------------------------------------------------------------
		{
			HRESULT hr;
			const Image* img = image->GetImage(0,0,0);
			THOR_ASSERT(img != 0, "No image data");
			size_t nimg = image->GetImageCount();
			ThWideString absPath = m_Pipeline->MakeAbsolutePath(input.m_OutputPath);

			THOR_INF("Output image parameters:")(textureToolsLogTag);
			ThTextureToolsUtils::PrintInfo( info );

			switch( input.m_Options->FileFormat.GetValueEnum() )
			{
			case eOutputFileFormat::DDS:
				hr = SaveToDDSFile( img, nimg, info,
					(input.m_Options->UseDx10HeaderDDS.GetValue()) ? (DDS_FLAGS_FORCE_DX10_EXT|DDS_FLAGS_FORCE_DX10_EXT_MISC2) : DDS_FLAGS_NONE, 
					absPath.c_str() );
				break;

			case eOutputFileFormat::TGA:
				hr = SaveToTGAFile( img[0], absPath.c_str() );
				break;

			default:
				hr = SaveToWICFile( img, nimg, WIC_FLAGS_ALL_FRAMES, GetWICCodec( static_cast<WICCodecs>(input.m_Options->FileFormat.GetValueEnum()) ), absPath.c_str() );
				break;
			}

			if(FAILED(hr))
			{
				THOR_ERR_W("Failed to write file %ls hr = %x")(textureToolsLogTag, absPath.c_str(), hr);
				return;
			}
			else
			{
				ThVector< ThPair<ThString, TheImporterOptionsPtr> >items;
				items.PushBack(ThPair<ThString, TheImporterOptionsPtr>(input.m_Hash, input.m_Options));
				TheFileMetadataPtr metadata = m_Pipeline->CreateMetadata(items);
				m_Pipeline->WriteImportedFileMetadata(input.m_InputPath, metadata);
			}
		}
	}

	ThBool IsTagFailed(ThSize tag)const
	{
		if (m_FailedTags.find(tag) != m_FailedTags.end())
			return true;
		else
			return false;
	}

	void AddFailedTag(ThSize tag)
	{
		m_FailedTags.insert(tag);
	}

	typedef tbb::concurrent_unordered_set<ThSize> FailedTagSet;

	typedef std::tuple<continue_msg, ProcessorInput> MultiFunctionPorts;

	typedef queue_node<InputType> SourceNode;
	typedef limiter_node<InputType> LimiterNode;
	typedef function_node<InputType, ProcessorInput > ImageLoaderNode;
	typedef function_node<ProcessorInput, ProcessorInput> ImageProcessorNode;
	typedef function_node<ProcessorInput> OutputNode;

	SourceNode* m_Source;
	LimiterNode* m_Limiter;
	ImageLoaderNode* m_Loader;
	ImageProcessorNode* m_Decompress;
	ImageProcessorNode* m_FlipRotate;
	ImageProcessorNode* m_Resize;
	ImageProcessorNode* m_ConvertFormat;
	ImageProcessorNode* m_PremultiplyAlpha;
	ImageProcessorNode* m_Compress;
	ImageProcessorNode* m_GenerateMipmaps;
	OutputNode* m_Output;
	ThContentPipeline* m_Pipeline;
	//holds a tag of an image sequence that has some failed stages, these images are discarded by other processors
	FailedTagSet m_FailedTags;

	graph* m_Graph;
};

struct ImageArrayProcessingGraph : public ImageProcessingGraph
{
	typedef tbb::concurrent_vector<ProcessorInput> ImageList;
	typedef std::tuple<ImageList, continue_msg> BufferingNodePorts;
	typedef tbb::concurrent_unordered_map<ThSize, ImageList> ImageSlicesMap;
	typedef multifunction_node<ProcessorInput, BufferingNodePorts> BufferingNode;
	typedef function_node<ImageList> AssembleNode;

	ImageSlicesMap m_Images;
	BufferingNode* m_BufferingNode;
	AssembleNode* m_AssembleNode;

	const ImageList& InsertImageStep(const ProcessorInput &input, ThSize& failedCounter)
	{
		failedCounter = 0;
		//check for failed image sequences and cleanup if necessary
		for (auto i = m_Images.begin(); i != m_Images.end(); ++i)
		{
			if (IsTagFailed(i->first))
			{
				failedCounter += i->second.size();
				for (auto j = i->second.begin(); j != i->second.end(); ++j)
				{
					delete j->m_Image;
					j->m_Image = 0;
				}
			}
		}

		auto imageList = m_Images.insert(ImageSlicesMap::value_type(input.m_Tag, ImageList()));
		imageList.first->second.push_back(input);
		return imageList.first->second;
	}

	void AssembleImagesStep(const ImageList& input)
	{
		HRESULT hr = 0;
		std::vector<Image> imageArray;
		imageArray.resize(input.size());
		ThContentPipeline::MetadataPairs mp;
		mp.Resize(input.size());

		for (auto it = input.cbegin(); it != input.cend(); ++it)
		{
			const Image* img = it->m_Image->GetImage(0,0,0);
			THOR_ASSERT(img != 0, "Image is null.");
			imageArray[it->m_Index] = *img;
			mp[it->m_Index].First() = it->m_Hash;
			mp[it->m_Index].Second() = it->m_Options;
		}

		const ThWideString& outputPath = input[0].m_OutputPath;

		ScratchImage result;

		switch (input[0].m_ArrayType)
		{
		case eTextureArrayType::VOLUME_MAP:
			hr = result.Initialize3DFromImages(&imageArray[0], imageArray.size());
			break;

		case eTextureArrayType::TEXTURE_ARRAY:
			hr = result.InitializeArrayFromImages(&imageArray[0], imageArray.size(), false);
			break;

		case eTextureArrayType::CUBEMAP:
		case eTextureArrayType::CUBEMAP_ARRAY:
			hr = result.InitializeCubeFromImages(&imageArray[0], imageArray.size());
			break;
		}

		if (FAILED(hr))
		{
			THOR_ERR_W("Failed building result image %ls , hr = %X")(textureToolsLogTag, outputPath.c_str(), hr);
			return;
		}

		// Write texture
		ThTextureToolsUtils::PrintInfo( result.GetMetadata() );

		ThWideString absOutputPath = m_Pipeline->MakeAbsolutePath(outputPath);

		hr = SaveToDDSFile(result.GetImages(), result.GetImageCount(), result.GetMetadata(),
			(input[0].m_Options->UseDx10HeaderDDS.GetValue()) ? (DDS_FLAGS_FORCE_DX10_EXT|DDS_FLAGS_FORCE_DX10_EXT_MISC2) : DDS_FLAGS_NONE, 
			absOutputPath.c_str());

		if (FAILED(hr))
		{
			THOR_ERR_W("Failed to save result image %ls , hr = %X")(textureToolsLogTag, absOutputPath.c_str(), hr);
		}
		else
		{
			m_Pipeline->WriteImportedFileMetadata(outputPath, m_Pipeline->CreateMetadata(mp));
		}
	}

	ImageArrayProcessingGraph(ThContentPipeline* pipeline, graph& g)
		:
	ImageProcessingGraph(pipeline, g)
	{
		
	}

	virtual void InitNodes(ThSize maxImagesAtOnce)
	{
		ImageProcessingGraph::InitNodes(maxImagesAtOnce);

		m_BufferingNode = new BufferingNode(*m_Graph, unlimited, 
			[this] (const ProcessorInput &input, BufferingNode::output_ports_type &ports)
		{
			ThSize failedImageCount = 0;

			auto lst = InsertImageStep(input, failedImageCount);

			//pass image array to the AssembleNode
			if (input.m_NumItems == lst.size())
			{
				std::get<0>(ports).try_put(lst);
			}

			//report number of failed images back to the limiter node
			for (ThSize i = 0; i < failedImageCount; ++i)
			{
				std::get<1>(ports).try_put(continue_msg());
			}

			//allow more images to be processed after buffering processed one
			std::get<1>(ports).try_put(continue_msg());
		}
		);

		m_AssembleNode = new AssembleNode(*m_Graph, unlimited, 
			[this] (const ImageList &input)->continue_msg
		{
			AssembleImagesStep(input);

			//decrement the limiter node as many times as there are images under this tag
			for (ThSize i = 0; i < input.size(); ++i)
			{
				delete input[i].m_Image;
			}

			return continue_msg();
		}
		);
	}

	virtual void LinkNodes()
	{
		make_edge(*m_Source, *m_Limiter);
		make_edge(*m_Limiter, *m_Loader);
		make_edge(*m_Loader, *m_Decompress);
		make_edge(*m_Decompress, *m_Resize);
		make_edge(*m_Resize, *m_ConvertFormat);
		make_edge(*m_ConvertFormat, *m_BufferingNode);
		make_edge(output_port<0>(*m_BufferingNode), *m_AssembleNode);
		make_edge(output_port<1>(*m_BufferingNode), m_Limiter->decrement);
	}

	~ImageArrayProcessingGraph()
	{
		delete m_BufferingNode;
		delete m_AssembleNode;
	}
};

ThTextureImporter::ThTextureImporter()
{
	m_Rules = new TheTextureToolsRules();
	m_Rules->DefaultImportOptions = new TheTextureImportOptions();
}

TheImportRulesPtr ThTextureImporter::GetImportRules()const
{
	return m_Rules;
}

void ThTextureImporter::SetImportRules(const TheImportRulesPtr& options)
{
	m_Rules = options;
}

ThHashSet<ThWideString> ThTextureImporter::GetSupportedFileExtensions()const
{
	ThHashSet<ThWideString> extensions;

	extensions.Insert(L".dds");
	extensions.Insert(L".jpg");
	extensions.Insert(L".jpe");
	extensions.Insert(L".jpeg");
	extensions.Insert(L".png");
	extensions.Insert(L".bmp");
	extensions.Insert(L".tiff");
	extensions.Insert(L".gif");
	extensions.Insert(L".jxr");
	extensions.Insert(L".psd");

	return extensions;
}

void ThTextureImporter::Import(ThContentPipeline* pipeline)
{	
	HRESULT hr;

	// Initialize COM (needed for WIC)
	if( FAILED( hr = CoInitializeEx(nullptr, COINIT_MULTITHREADED) ) )
	{
		THOR_ERR("Failed to initialize COM (%08X), texture importer is unable to proceed.")(textureToolsLogTag, hr);
		return;
	}

	ThSize maxConcurrency = 8;

	//collect all supported files to import
	
	ThHashSet<ThWideString> filesToProcess;

	pipeline->CollectInputFilesWithExtensions(GetSupportedFileExtensions(), filesToProcess);

	//store file hashes
	ThHashMap<ThWideString, ThString> fileHashes;
	//image files with no rules assigned to them
	ThHashSet<ThWideString> filesToProcessWithDefaultRules(filesToProcess);
	//enforce unique output file names
	ThHashSet<ThWideString> outputPaths;

	//process files with individual rules
	graph ig;
	ImageProcessingGraph imageGraph(pipeline, ig);
	imageGraph.InitNodes(maxConcurrency);
	imageGraph.LinkNodes();
	graph aig;
	ImageArrayProcessingGraph imageArrayGraph(pipeline, aig);
	
	ThSize imageTag = 0;

	for (ThSize i = 0; i < m_Rules->PerFileImportOptions.GetSize(); ++i)
	{
		const TheTextureToolsRules::PerFileImportOptionsTypename::KeyValuePair& curItem = m_Rules->PerFileImportOptions.GetItem(i);
		auto curInputPath = curItem.Key();
		
		ThWideString curOutputPath;

		filesToProcessWithDefaultRules.Erase(curInputPath);
		
		if (!MakeOutputPath(pipeline, false, curInputPath, curItem.Value().GetValue(), curOutputPath))
			continue;

		if (!outputPaths.Insert(curOutputPath))
		{
			THOR_ERR_W("Duplicate output path %ls, this rule will be skipped.")(textureToolsLogTag, curOutputPath.c_str());
			continue;
		}

		if (filesToProcess.Find(curInputPath) == filesToProcess.End())
		{
			THOR_ERR_W("Required file %ls is not found.")(textureToolsLogTag, curInputPath.c_str());
			continue;
		}

		ThString hash = pipeline->ComputeFileHash(curInputPath);

		ThContentPipeline::MetadataPairs mp;
		mp.PushBack(ThContentPipeline::MetadataPairs::ValueType(hash, curItem.Value().GetValue()));
		
		if (pipeline->FileExists(curOutputPath) && pipeline->CheckMetadata(curInputPath, mp))
		{
			THOR_ERR_W("Texture %ls is already imported with the same options.")(textureToolsLogTag, curInputPath.c_str());
			continue;
		}

		imageGraph.m_Source->try_put(InputType(curInputPath, curOutputPath, hash, curItem.Value().GetValue(), imageTag, 0, 1));
		++imageTag;
	}
	//preprocess texture arrays
	ThSize maxArraySize = 0;
	//holds tex array rules item indices which have invalid configuration
	ThHashSet<ThSize> invalidTexArrayRules;

	for (ThSize i = 0; i < m_Rules->ArrayImportOptions.GetSize(); ++i)
	{
		auto curItem = m_Rules->ArrayImportOptions.GetItem(i);
		auto curArrayOptions = curItem.Value().GetValue();
		auto outputPath = curItem.Key();
		ThWideString curOutputPath;
		
		if (!MakeOutputPath(pipeline, true, outputPath, curArrayOptions, curOutputPath))
			continue;

		ThWideString curIntermediatePath = pipeline->CombinePath(pipeline->GetIntermediateDirectory(), outputPath);

		ThSize curSize = curArrayOptions->TexturesToImport.GetSize();

		if (curSize == 0)
		{
			THOR_ERR_W("Detected invalid texture array import rule with no images, output path %ls .")(textureToolsLogTag, curOutputPath.c_str());
			invalidTexArrayRules.Insert(i);
			continue;
		}

		if (!outputPaths.Insert(curOutputPath))
		{
			THOR_ERR_W("Duplicate output path %ls, this array rule will be skipped.")(textureToolsLogTag, curOutputPath.c_str());
			invalidTexArrayRules.Insert(i);
		}

		eTextureArrayType::Val arrayType = curArrayOptions->ArrayType.GetValueEnum();

		if (arrayType == eTextureArrayType::CUBEMAP || arrayType == eTextureArrayType::CUBEMAP_ARRAY)
		{
			if (curSize % 6 != 0)
			{
				THOR_ERR_W("Detected invalid cube map import rule with number of input images indivisible by 6, output path %ls .")(textureToolsLogTag, curOutputPath.c_str());
				invalidTexArrayRules.Insert(i);
			}
		}
		
		if (curSize > maxArraySize)
		{
			maxArraySize = curSize;
		}

		ThContentPipeline::MetadataPairs mp;

		//process image array slices
		for (ThSize j = 0; j < curArrayOptions->TexturesToImport.GetSize(); ++j)
		{
			auto inputSlicePath = curArrayOptions->TexturesToImport.GetItemValue(j);

			if (filesToProcess.Find(inputSlicePath) == filesToProcess.End())
			{
				THOR_ERR_W("Required input file not found %ls, output path %ls .")(textureToolsLogTag, inputSlicePath, curOutputPath.c_str());
				invalidTexArrayRules.Insert(i);
			}

			filesToProcessWithDefaultRules.Erase(inputSlicePath);

			ThString hash = pipeline->ComputeFileHash(inputSlicePath);
			mp.PushBack(ThContentPipeline::MetadataPairs::ValueType(hash, curArrayOptions));

			fileHashes.Insert(inputSlicePath, hash);
		}

		if (pipeline->FileExists(curOutputPath) && pipeline->CheckMetadata(curIntermediatePath, mp))
		{
			THOR_INF_W("Texture array with output path %ls is already imported with the same options, source images are unchanged.")(textureToolsLogTag, curOutputPath.c_str());
			invalidTexArrayRules.Insert(i);
		}
	}

	//process texture arrays
	imageArrayGraph.InitNodes(/*maxArraySize*/ maxConcurrency);
	imageArrayGraph.LinkNodes();

	for (ThSize i = 0; i < m_Rules->ArrayImportOptions.GetSize(); ++i)
	{
		if (invalidTexArrayRules.Find(i) != invalidTexArrayRules.End())
			continue;

		auto curItem = m_Rules->ArrayImportOptions.GetItem(i);
		auto curArrayOptions = m_Rules->ArrayImportOptions.GetItemValue(i);
		ThSize curSize = curArrayOptions->TexturesToImport.GetSize();
		
		ThWideString curOutputPath;

		if (!MakeOutputPath(pipeline, true, curItem.Key(), curArrayOptions, curOutputPath))
			continue;

		for (ThSize j = 0; j < curSize; ++j)
		{
			auto inputSlicePath = curArrayOptions->TexturesToImport.GetItemValue(j);

			auto hash = fileHashes.Find(inputSlicePath);

			if (hash != fileHashes.End())
				imageArrayGraph.m_Source->try_put(InputType(inputSlicePath, curOutputPath, hash->Value(), curArrayOptions, i, j, curSize, curArrayOptions->ArrayType.GetValueEnum()));
			else
			{
				THOR_ERR_W("Failed to compute hash for file %ls .")(textureToolsLogTag, inputSlicePath.c_str());
				imageArrayGraph.AddFailedTag(i);
			}
		}
	}

	//process remaining files with default options
	for (ThSize i = 0; i < filesToProcessWithDefaultRules.Size(); ++i)
	{
		const ThWideString& curInputPath = filesToProcessWithDefaultRules.GetItem(i).Key();
		ThString hash = pipeline->ComputeFileHash(curInputPath);

		ThWideString curOutputPath;
		
		if (!MakeOutputPath(pipeline, false, curInputPath, m_Rules->DefaultImportOptions.GetValue(), curOutputPath))
			continue;

		ThContentPipeline::MetadataPairs mp;
		mp.PushBack(ThContentPipeline::MetadataPairs::ValueType(hash, m_Rules->DefaultImportOptions.GetValue()));

		if (pipeline->FileExists(curOutputPath) && pipeline->CheckMetadata(curInputPath, mp))
		{
			THOR_INF_W("Texture %ls is already imported with the same options.")(textureToolsLogTag, curInputPath.c_str());
			continue;
		}

		ThBool putResult = imageGraph.m_Source->try_put(InputType(curInputPath, curOutputPath, hash, m_Rules->DefaultImportOptions.GetValue(), imageTag, 0, 1));
		++imageTag;
	}

	ig.wait_for_all();
	aig.wait_for_all();
}

ThiType* ThTextureImporter::GetType()const
{
	return ThType<ThTextureImporter>::Instance();
}

ThBool ThTextureImporter::PreprocessTextureArrayImportOptions(ThContentPipeline* pipeline, ContentToolsProtocol::TheTextureArrayImportOptionsPtr options)
{
	TexMetadata info;
	ThU32 ddsLoadFlags = 0;

	if (options->UseDwordAlignmentDDS.GetValue())
		ddsLoadFlags |= eDDSLoadFlags::UseDwordAlignment;

	if (options->ExpandLuminanceDDS.GetValue())
		ddsLoadFlags |= eDDSLoadFlags::ExpandLuminance;

	if (options->UseTypelessUnormFormatDDS.GetValue())
		ddsLoadFlags |= eDDSLoadFlags::UseTypelessUnormFormat;

	if (options->UseTypelessFloatFormatDDS.GetValue())
		ddsLoadFlags |= eDDSLoadFlags::UseTypelessFloatFormat;

	const ThWideString& imagePath = options->TexturesToImport.GetItemValue(0);

	if (!ThTextureToolsUtils::LoadImageMetadata(imagePath, pipeline, ddsLoadFlags, info))
	{
		THOR_ERR_W("Failed to read image metadata from file %ls")(textureToolsLogTag, imagePath.c_str());
		return false;
	}

	options->TargetFormat = ThTextureToolsUtils::TranslateFormatFromDXGI(info.format);

	options->MipLevelsOverride = 1;

	/*if (options->FileFormat.GetValueEnum() != eOutputFileFormat::DDS)
	{
		options->MipLevelsOverride = 1;
	}
	else
	{
		options->MipLevelsOverride = info.mipLevels;
	}*/

	options->WidthOverride = info.width;
	options->HeightOverrive = info.height;

	return true;
}

ThBool ThTextureImporter::MakeOutputPath(ThContentPipeline* pipeline, ThBool isArray, const ThWideString& inputPath, const TheTextureImportOptionsPtr& options, ThWideString& outputPath)
{
	ThWideString inputDir = pipeline->GetDirectory(inputPath);
	ThWideString inputFilename = pipeline->GetFilename(inputPath);
	ThWideString inputFileExtension = pipeline->GetExtension(inputPath);

	if (isArray)
		outputPath = pipeline->CombinePath(pipeline->GetOutputDirectory(), inputDir);
	else
		outputPath = pipeline->ConvertToOutputPath(inputDir);

	if (!pipeline->CreateDirectory(outputPath))
		return false;

	ThWideString outputFilename = options->OutputFilePrefix.GetValue() + inputFilename + options->OutputFileSuffix.GetValue();
	outputPath = pipeline->CombinePath(outputPath, outputFilename);
	outputPath = pipeline->ReplaceExtension(outputPath, ThTextureToolsUtils::GetOutputFileExtension(options->FileFormat.GetValueEnum()));

	return true;
}

}
