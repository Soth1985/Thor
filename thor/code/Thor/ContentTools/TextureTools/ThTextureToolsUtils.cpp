#include <Thor/ContentTools/TextureTools/ThTextureToolsUtils.h>
#include <Thor/ContentTools/ContentPipeline/ThContentPipeline.h>

using namespace Thor::ContentToolsProtocol;
using namespace DirectX;

namespace Thor
{

ThU32 ThTextureToolsUtils::TranslateFilter(eImageFilter::Val filter)
{
	if (filter == eImageFilter::POINT)
		return TEX_FILTER_POINT;
	else if (filter == eImageFilter::LINEAR)
		return TEX_FILTER_LINEAR;
	else if (filter == eImageFilter::CUBIC)
		return TEX_FILTER_CUBIC;
	else if (filter == eImageFilter::FANT)
		return TEX_FILTER_FANT;
	else if (filter == eImageFilter::BOX)
		return TEX_FILTER_BOX;
	else if (filter == eImageFilter::TRIANGLE)
		return TEX_FILTER_TRIANGLE;
	else if (filter == eImageFilter::POINT_DITHER)
		return TEX_FILTER_POINT | TEX_FILTER_DITHER;
	else if (filter == eImageFilter::LINEAR_DITHER)
		return TEX_FILTER_LINEAR | TEX_FILTER_DITHER;
	else if (filter == eImageFilter::CUBIC_DITHER)
		return TEX_FILTER_CUBIC | TEX_FILTER_DITHER;
	else if (filter == eImageFilter::FANT_DITHER)
		return TEX_FILTER_FANT | TEX_FILTER_DITHER;
	else if (filter == eImageFilter::BOX_DITHER)
		return TEX_FILTER_BOX | TEX_FILTER_DITHER;
	else if (filter == eImageFilter::TRIANGLE_DITHER)
		return TEX_FILTER_TRIANGLE | TEX_FILTER_DITHER;
	else if (filter == eImageFilter::POINT_DITHER_DIFFUSION)
		return TEX_FILTER_POINT | TEX_FILTER_DITHER_DIFFUSION;
	else if (filter == eImageFilter::LINEAR_DITHER_DIFFUSION)
		return TEX_FILTER_LINEAR | TEX_FILTER_DITHER_DIFFUSION;
	else if (filter == eImageFilter::CUBIC_DITHER_DIFFUSION)
		return TEX_FILTER_CUBIC | TEX_FILTER_DITHER_DIFFUSION;
	else if (filter == eImageFilter::FANT_DITHER_DIFFUSION)
		return TEX_FILTER_FANT | TEX_FILTER_DITHER_DIFFUSION;
	else if (filter == eImageFilter::BOX_DITHER_DIFFUSION)
		return TEX_FILTER_BOX  | TEX_FILTER_DITHER_DIFFUSION;
	else if (filter == eImageFilter::TRIANGLE_DITHER_DIFFUSION)
		return TEX_FILTER_TRIANGLE | TEX_FILTER_DITHER_DIFFUSION;
		
	return TEX_FILTER_DEFAULT;
}

DXGI_FORMAT ThTextureToolsUtils::TranslateFormat(eImageFormat::Val format)
{
	if (format == eImageFormat::R32G32B32A32_FLOAT)
		return DXGI_FORMAT_R32G32B32A32_FLOAT;
	else if (format == eImageFormat::R32G32B32A32_UINT)
		return DXGI_FORMAT_R32G32B32A32_UINT;
	else if (format == eImageFormat::R32G32B32A32_SINT)
		return DXGI_FORMAT_R32G32B32A32_SINT;
	else if (format == eImageFormat::R32G32B32_FLOAT)
		return DXGI_FORMAT_R32G32B32_FLOAT;
	else if (format == eImageFormat::R32G32B32_UINT)
		return DXGI_FORMAT_R32G32B32_UINT;
	else if (format == eImageFormat::R32G32B32_SINT)
		return DXGI_FORMAT_R32G32B32_SINT;
	else if (format == eImageFormat::R16G16B16A16_FLOAT)
		return DXGI_FORMAT_R16G16B16A16_FLOAT;
	else if (format == eImageFormat::R16G16B16A16_UNORM)
		return DXGI_FORMAT_R16G16B16A16_UNORM;
	else if (format == eImageFormat::R16G16B16A16_UINT)
		return DXGI_FORMAT_R16G16B16A16_UINT;
	else if (format == eImageFormat::R16G16B16A16_SNORM)
		return DXGI_FORMAT_R16G16B16A16_SNORM;
	else if (format == eImageFormat::R16G16B16A16_SINT)
		return DXGI_FORMAT_R16G16B16A16_SINT;
	else if (format == eImageFormat::R32G32_FLOAT)
		return DXGI_FORMAT_R32G32_FLOAT;
	else if (format == eImageFormat::R32G32_UINT)
		return DXGI_FORMAT_R32G32_UINT;
	else if (format == eImageFormat::R32G32_SINT)
		return DXGI_FORMAT_R32G32_SINT;
	else if (format == eImageFormat::R10G10B10A2_UNORM)
		return DXGI_FORMAT_R10G10B10A2_UNORM;
	else if (format == eImageFormat::R10G10B10A2_UINT)
		return DXGI_FORMAT_R10G10B10A2_UINT;
	else if (format == eImageFormat::R11G11B10_FLOAT)
		return DXGI_FORMAT_R11G11B10_FLOAT;
	else if (format == eImageFormat::R8G8B8A8_UNORM)
		return DXGI_FORMAT_R8G8B8A8_UNORM;
	else if (format == eImageFormat::R8G8B8A8_UNORM_SRGB)
		return DXGI_FORMAT_R8G8B8A8_UNORM_SRGB;
	else if (format == eImageFormat::R8G8B8A8_UINT)
		return DXGI_FORMAT_R8G8B8A8_UINT;
	else if (format == eImageFormat::R8G8B8A8_SNORM)
		return DXGI_FORMAT_R8G8B8A8_SNORM;
	else if (format == eImageFormat::R8G8B8A8_SINT)
		return DXGI_FORMAT_R8G8B8A8_SINT;
	else if (format == eImageFormat::R16G16_FLOAT)
		return DXGI_FORMAT_R16G16_FLOAT;
	else if (format == eImageFormat::R16G16_UNORM)
		return DXGI_FORMAT_R16G16_UNORM;
	else if (format == eImageFormat::R16G16_UINT)
		return DXGI_FORMAT_R16G16_UINT;
	else if (format == eImageFormat::R16G16_SNORM)
		return DXGI_FORMAT_R16G16_SNORM;
	else if (format == eImageFormat::R16G16_SINT)
		return DXGI_FORMAT_R16G16_SINT;
	else if (format == eImageFormat::R32_FLOAT)
		return DXGI_FORMAT_R32_FLOAT;
	else if (format == eImageFormat::R32_UINT)
		return DXGI_FORMAT_R32_UINT;
	else if (format == eImageFormat::R32_SINT)
		return DXGI_FORMAT_R32_SINT;
	else if (format == eImageFormat::R8G8_UNORM)
		return DXGI_FORMAT_R8G8_UNORM;
	else if (format == eImageFormat::R8G8_UINT)
		return DXGI_FORMAT_R8G8_UINT;
	else if (format == eImageFormat::R8G8_SNORM)
		return DXGI_FORMAT_R8G8_SNORM;
	else if (format == eImageFormat::R8G8_SINT)
		return DXGI_FORMAT_R8G8_SINT;
	else if (format == eImageFormat::R16_FLOAT)
		return DXGI_FORMAT_R16_FLOAT;
	else if (format == eImageFormat::R16_UNORM)
		return DXGI_FORMAT_R16_UNORM;
	else if (format == eImageFormat::R16_UINT)
		return DXGI_FORMAT_R16_UINT;
	else if (format == eImageFormat::R16_SNORM)
		return DXGI_FORMAT_R16_SNORM;
	else if (format == eImageFormat::R16_SINT)
		return DXGI_FORMAT_R16_SINT;
	else if (format == eImageFormat::R8_UNORM)
		return DXGI_FORMAT_R8_UNORM;
	else if (format == eImageFormat::R8_UINT)
		return DXGI_FORMAT_R8_UINT;
	else if (format == eImageFormat::R8_SNORM)
		return DXGI_FORMAT_R8_SNORM;
	else if (format == eImageFormat::R8_SINT)
		return DXGI_FORMAT_R8_SINT;
	else if (format == eImageFormat::A8_UNORM)
		return DXGI_FORMAT_A8_UNORM;
	else if (format == eImageFormat::R9G9B9E5_SHAREDEXP)
		return DXGI_FORMAT_R9G9B9E5_SHAREDEXP;
	else if (format == eImageFormat::R8G8_B8G8_UNORM)
		return DXGI_FORMAT_R8G8_B8G8_UNORM;
	else if (format == eImageFormat::G8R8_G8B8_UNORM)
		return DXGI_FORMAT_G8R8_G8B8_UNORM;
	else if (format == eImageFormat::BC1_UNORM)
		return DXGI_FORMAT_BC1_UNORM;
	else if (format == eImageFormat::BC1_UNORM_SRGB)
		return DXGI_FORMAT_BC1_UNORM_SRGB;
	else if (format == eImageFormat::BC2_UNORM)
		return DXGI_FORMAT_BC2_UNORM;
	else if (format == eImageFormat::BC2_UNORM_SRGB)
		return DXGI_FORMAT_BC2_UNORM_SRGB;
	else if (format == eImageFormat::BC3_UNORM)
		return DXGI_FORMAT_BC3_UNORM;
	else if (format == eImageFormat::BC3_UNORM_SRGB)
		return DXGI_FORMAT_BC3_UNORM_SRGB;
	else if (format == eImageFormat::BC4_UNORM)
		return DXGI_FORMAT_BC4_UNORM;
	else if (format == eImageFormat::BC4_SNORM)
		return DXGI_FORMAT_BC4_SNORM;
	else if (format == eImageFormat::BC5_UNORM)
		return DXGI_FORMAT_BC5_UNORM;
	else if (format == eImageFormat::BC5_SNORM)
		return DXGI_FORMAT_BC5_SNORM;
	else if (format == eImageFormat::B5G6R5_UNORM)
		return DXGI_FORMAT_B5G6R5_UNORM;
	else if (format == eImageFormat::B5G5R5A1_UNORM)
		return DXGI_FORMAT_B5G5R5A1_UNORM;
	else if (format == eImageFormat::B8G8R8A8_UNORM)
		return DXGI_FORMAT_B8G8R8A8_UNORM;
	else if (format == eImageFormat::B8G8R8X8_UNORM)
		return DXGI_FORMAT_B8G8R8X8_UNORM;
	else if (format == eImageFormat::R10G10B10_XR_BIAS_A2_UNORM)
		return DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM;
	else if (format == eImageFormat::B8G8R8A8_UNORM_SRGB)
		return DXGI_FORMAT_B8G8R8A8_UNORM_SRGB;
	else if (format == eImageFormat::B8G8R8X8_UNORM_SRGB)
		return DXGI_FORMAT_B8G8R8X8_UNORM_SRGB;
	else if (format == eImageFormat::BC6H_UF16)
		return DXGI_FORMAT_BC6H_UF16;
	else if (format == eImageFormat::BC6H_SF16)
		return DXGI_FORMAT_BC6H_SF16;
	else if (format == eImageFormat::BC7_UNORM)
		return DXGI_FORMAT_BC7_UNORM;
	else if (format == eImageFormat::BC7_UNORM_SRGB)
		return DXGI_FORMAT_BC7_UNORM_SRGB;
	//else if (format == eImageFormat::B4G4R4A4_UNORM)
	//	return DXGI_FORMAT_B4G4R4A4_UNORM;

	return DXGI_FORMAT_UNKNOWN;
}

ContentToolsProtocol::eImageFormat::Val ThTextureToolsUtils::TranslateFormatFromDXGI(DXGI_FORMAT format)
{
	if (format == DXGI_FORMAT_R32G32B32A32_FLOAT)
		return eImageFormat::R32G32B32A32_FLOAT;
	else if (format == DXGI_FORMAT_R32G32B32A32_UINT)
		return eImageFormat::R32G32B32A32_UINT;
	else if (format == DXGI_FORMAT_R32G32B32A32_SINT)
		return eImageFormat::R32G32B32A32_SINT;
	else if (format == DXGI_FORMAT_R32G32B32_FLOAT)
		return eImageFormat::R32G32B32_FLOAT;
	else if (format == DXGI_FORMAT_R32G32B32_UINT)
		return eImageFormat::R32G32B32_UINT;
	else if (format == DXGI_FORMAT_R32G32B32_SINT)
		return eImageFormat::R32G32B32_SINT;
	else if (format == DXGI_FORMAT_R16G16B16A16_FLOAT)
		return eImageFormat::R16G16B16A16_FLOAT;
	else if (format == DXGI_FORMAT_R16G16B16A16_UNORM)
		return eImageFormat::R16G16B16A16_UNORM;
	else if (format == DXGI_FORMAT_R16G16B16A16_UINT)
		return eImageFormat::R16G16B16A16_UINT;
	else if (format == DXGI_FORMAT_R16G16B16A16_SNORM)
		return eImageFormat::R16G16B16A16_SNORM;
	else if (format == DXGI_FORMAT_R16G16B16A16_SINT)
		return eImageFormat::R16G16B16A16_SINT;
	else if (format == DXGI_FORMAT_R32G32_FLOAT)
		return eImageFormat::R32G32_FLOAT;
	else if (format == DXGI_FORMAT_R32G32_UINT)
		return eImageFormat::R32G32_UINT;
	else if (format == DXGI_FORMAT_R32G32_SINT)
		return eImageFormat::R32G32_SINT;
	else if (format == DXGI_FORMAT_R10G10B10A2_UNORM)
		return eImageFormat::R10G10B10A2_UNORM;
	else if (format == DXGI_FORMAT_R10G10B10A2_UINT)
		return eImageFormat::R10G10B10A2_UINT;
	else if (format == DXGI_FORMAT_R11G11B10_FLOAT)
		return eImageFormat::R11G11B10_FLOAT;
	else if (format == DXGI_FORMAT_R8G8B8A8_UNORM)
		return eImageFormat::R8G8B8A8_UNORM;
	else if (format == DXGI_FORMAT_R8G8B8A8_UNORM_SRGB)
		return eImageFormat::R8G8B8A8_UNORM_SRGB;
	else if (format == DXGI_FORMAT_R8G8B8A8_UINT)
		return eImageFormat::R8G8B8A8_UINT;
	else if (format == DXGI_FORMAT_R8G8B8A8_SNORM)
		return eImageFormat::R8G8B8A8_SNORM;
	else if (format == DXGI_FORMAT_R8G8B8A8_SINT)
		return eImageFormat::R8G8B8A8_SINT;
	else if (format == DXGI_FORMAT_R16G16_FLOAT)
		return eImageFormat::R16G16_FLOAT;
	else if (format == DXGI_FORMAT_R16G16_UNORM)
		return eImageFormat::R16G16_UNORM;
	else if (format == DXGI_FORMAT_R16G16_UINT)
		return eImageFormat::R16G16_UINT;
	else if (format == DXGI_FORMAT_R16G16_SNORM)
		return eImageFormat::R16G16_SNORM;
	else if (format == DXGI_FORMAT_R16G16_SINT)
		return eImageFormat::R16G16_SINT;
	else if (format == DXGI_FORMAT_R32_FLOAT)
		return eImageFormat::R32_FLOAT;
	else if (format == DXGI_FORMAT_R32_UINT)
		return eImageFormat::R32_UINT;
	else if (format == DXGI_FORMAT_R32_SINT)
		return eImageFormat::R32_SINT;
	else if (format == DXGI_FORMAT_R8G8_UNORM)
		return eImageFormat::R8G8_UNORM;
	else if (format == DXGI_FORMAT_R8G8_UINT)
		return eImageFormat::R8G8_UINT;
	else if (format == DXGI_FORMAT_R8G8_SNORM)
		return eImageFormat::R8G8_SNORM;
	else if (format == DXGI_FORMAT_R8G8_SINT)
		return eImageFormat::R8G8_SINT;
	else if (format == DXGI_FORMAT_R16_FLOAT)
		return eImageFormat::R16_FLOAT;
	else if (format == DXGI_FORMAT_R16_UNORM)
		return eImageFormat::R16_UNORM;
	else if (format == DXGI_FORMAT_R16_UINT)
		return eImageFormat::R16_UINT;
	else if (format == DXGI_FORMAT_R16_SNORM)
		return eImageFormat::R16_SNORM;
	else if (format == DXGI_FORMAT_R16_SINT)
		return eImageFormat::R16_SINT;
	else if (format == DXGI_FORMAT_R8_UNORM)
		return eImageFormat::R8_UNORM;
	else if (format == DXGI_FORMAT_R8_UINT)
		return eImageFormat::R8_UINT;
	else if (format == DXGI_FORMAT_R8_SNORM)
		return eImageFormat::R8_SNORM;
	else if (format == DXGI_FORMAT_R8_SINT)
		return eImageFormat::R8_SINT;
	else if (format == DXGI_FORMAT_A8_UNORM)
		return eImageFormat::A8_UNORM;
	else if (format == DXGI_FORMAT_R9G9B9E5_SHAREDEXP)
		return eImageFormat::R9G9B9E5_SHAREDEXP;
	else if (format == DXGI_FORMAT_R8G8_B8G8_UNORM)
		return eImageFormat::R8G8_B8G8_UNORM;
	else if (format == DXGI_FORMAT_G8R8_G8B8_UNORM)
		return eImageFormat::G8R8_G8B8_UNORM;
	else if (format == DXGI_FORMAT_BC1_UNORM)
		return eImageFormat::BC1_UNORM;
	else if (format == DXGI_FORMAT_BC1_UNORM_SRGB)
		return eImageFormat::BC1_UNORM_SRGB;
	else if (format == DXGI_FORMAT_BC2_UNORM)
		return eImageFormat::BC2_UNORM;
	else if (format == DXGI_FORMAT_BC2_UNORM_SRGB)
		return eImageFormat::BC2_UNORM_SRGB;
	else if (format == DXGI_FORMAT_BC3_UNORM)
		return eImageFormat::BC3_UNORM;
	else if (format == DXGI_FORMAT_BC3_UNORM_SRGB)
		return eImageFormat::BC3_UNORM_SRGB;
	else if (format == DXGI_FORMAT_BC4_UNORM)
		return eImageFormat::BC4_UNORM;
	else if (format == DXGI_FORMAT_BC4_SNORM)
		return eImageFormat::BC4_SNORM;
	else if (format == DXGI_FORMAT_BC5_UNORM)
		return eImageFormat::BC5_UNORM;
	else if (format == DXGI_FORMAT_BC5_SNORM)
		return eImageFormat::BC5_SNORM;
	else if (format == DXGI_FORMAT_B5G6R5_UNORM)
		return eImageFormat::B5G6R5_UNORM;
	else if (format == DXGI_FORMAT_B5G5R5A1_UNORM)
		return eImageFormat::B5G5R5A1_UNORM;
	else if (format == DXGI_FORMAT_B8G8R8A8_UNORM)
		return eImageFormat::B8G8R8A8_UNORM;
	else if (format == DXGI_FORMAT_B8G8R8X8_UNORM)
		return eImageFormat::B8G8R8X8_UNORM;
	else if (format == DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM)
		return eImageFormat::R10G10B10_XR_BIAS_A2_UNORM;
	else if (format == DXGI_FORMAT_B8G8R8A8_UNORM_SRGB)
		return eImageFormat::B8G8R8A8_UNORM_SRGB;
	else if (format == DXGI_FORMAT_B8G8R8X8_UNORM_SRGB)
		return eImageFormat::B8G8R8X8_UNORM_SRGB;
	else if (format == DXGI_FORMAT_BC6H_UF16)
		return eImageFormat::BC6H_UF16;
	else if (format == DXGI_FORMAT_BC6H_SF16)
		return eImageFormat::BC6H_SF16;
	else if (format == DXGI_FORMAT_BC7_UNORM)
		return eImageFormat::BC7_UNORM;
	else if (format == DXGI_FORMAT_BC7_UNORM_SRGB)
		return eImageFormat::BC7_UNORM_SRGB;
	//else if (format == eImageFormat::B4G4R4A4_UNORM)
	//	return DXGI_FORMAT_B4G4R4A4_UNORM;

	return eImageFormat::UNKNOWN;
}

WICCodecs ThTextureToolsUtils::TranslateCodecToWIC(eOutputFileFormat::Val codec)
{
	if (codec == eOutputFileFormat::BMP)
		return WIC_CODEC_BMP;
	else if (codec == eOutputFileFormat::JPEG)
		return WIC_CODEC_JPEG;
	else if (codec == eOutputFileFormat::PNG)
		return WIC_CODEC_PNG;
	else if (codec == eOutputFileFormat::TIFF)
		return WIC_CODEC_TIFF;
	else if (codec == eOutputFileFormat::WDP)
		return WIC_CODEC_WMP;
	else if (codec == eOutputFileFormat::HDP)
		return WIC_CODEC_WMP;

	return WIC_CODEC_WMP;
}

ThWideString ThTextureToolsUtils::GetOutputFileExtension(eOutputFileFormat::Val codec)
{
	if (codec == eOutputFileFormat::BMP)
		return L".bmp";
	else if (codec == eOutputFileFormat::JPEG)
		return L".jpg";
	else if (codec == eOutputFileFormat::PNG)
		return L".png";
	else if (codec == eOutputFileFormat::TIFF)
		return L".tiff";
	else if (codec == eOutputFileFormat::WDP)
		return L".wdp";
	else if (codec == eOutputFileFormat::HDP)
		return L".hdp";
	else if (codec == eOutputFileFormat::DDS)
		return L".dds";
	else if (codec == eOutputFileFormat::TGA)
		return L".tga";

	return ThWideString();
}

static ThU32 TranslateFlagsDDS(ThU32 ddsLoadFlag)
{
	ThU32 ddsFlags = DDS_FLAGS_NONE;

	if (ddsLoadFlag & eDDSLoadFlags::UseDwordAlignment)
		ddsFlags |= DDS_FLAGS_LEGACY_DWORD;

	if (ddsLoadFlag & eDDSLoadFlags::ExpandLuminance)
		ddsFlags |= DDS_FLAGS_EXPAND_LUMINANCE;

	return ddsFlags;
}

void ThTextureToolsUtils::PrintInfo( const TexMetadata& info )
{
	ThString type;
		
	switch ( info.dimension )
	{
	case TEX_DIMENSION_TEXTURE1D:
		info.arraySize > 1 ? type = "1DArray" : type = "1D";
		break;

	case TEX_DIMENSION_TEXTURE2D:
		if ( info.IsCubemap() )
		{
			info.arraySize > 6 ? type = "CubeArray" : type = "Cube";
		}
		else
		{
			info.arraySize > 1 ? type = "2DArray" : type = "2D";
		}
		break;

	case TEX_DIMENSION_TEXTURE3D:
		type = "3D";
		break;
	}

	THOR_INF("		w=%Iu h=%Iu d=%Iu mip=%Iu fmt=%d type=%s")(textureToolsLogTag, info.width, info.height, info.depth,  info.mipLevels, info.format, type.c_str());
}

ThBool ThTextureToolsUtils::IsPow2(size_t x)
{
	return ((x != 0) && !(x & (x - 1)));
}

ThBool ThTextureToolsUtils::LoadImageMetadata(const ThWideString& path, ThContentPipeline* pipeline, ThU32 ddsLoadFlags, DirectX::TexMetadata& result)
{
	HRESULT hr;
	ThWideString inputFileExtension = pipeline->GetExtension(path);

	if (inputFileExtension == L".dds")
	{
		ThU32 ddsFlags = TranslateFlagsDDS(ddsLoadFlags);

		ThWideString absPath = pipeline->MakeAbsolutePath(path);

		hr = GetMetadataFromDDSFile( absPath.c_str(), ddsFlags, result);

		if ( FAILED(hr) )
		{
			return false;
		}

		if ( IsTypeless( result.format ) )
		{
			if (ddsLoadFlags & eDDSLoadFlags::UseTypelessUnormFormat)
			{
				result.format = MakeTypelessUNORM( result.format );
			}
			else if (ddsLoadFlags & eDDSLoadFlags::UseTypelessFloatFormat)
			{
				result.format = MakeTypelessFLOAT( result.format );
			}

			if ( IsTypeless( result.format ) )
			{
				return false;
			}
		}
	}
	else if (inputFileExtension == L".tga")
	{
		ThWideString absPath = pipeline->MakeAbsolutePath(path);
		hr = GetMetadataFromTGAFile( absPath.c_str(), result );
		if ( FAILED(hr) )
		{
			return false;
		}
	}
	else
	{
		ThWideString absPath = pipeline->MakeAbsolutePath(path);
		hr = GetMetadataFromWICFile(absPath.c_str(), 0, result);

		if ( FAILED(hr) )
		{
			return false;
		}
	}

	return true;
}

ThBool ThTextureToolsUtils::LoadImage(const ThWideString& path, ThContentPipeline* pipeline, ThU32 ddsLoadFlags, ThU32 imageFilter, ScratchImage** result)
{
	HRESULT hr;
	ThWideString inputFileExtension = pipeline->GetExtension(path);
	TexMetadata info;

	ScratchImage *image = new ScratchImage();

	if (!image)
	{
		return false;
	}

	*result = image;

	if (inputFileExtension == L".dds")
	{
		ThU32 ddsFlags = TranslateFlagsDDS(ddsLoadFlags);

		ThWideString absPath = pipeline->MakeAbsolutePath(path);

		hr = LoadFromDDSFile( absPath.c_str(), ddsFlags, &info, *image );

		if ( FAILED(hr) )
		{
			delete image;
			return false;
		}

		if ( IsTypeless( info.format ) )
		{
			if (ddsLoadFlags & eDDSLoadFlags::UseTypelessUnormFormat)
			{
				info.format = MakeTypelessUNORM( info.format );
			}
			else if (ddsLoadFlags & eDDSLoadFlags::UseTypelessFloatFormat)
			{
				info.format = MakeTypelessFLOAT( info.format );
			}

			if ( IsTypeless( info.format ) )
			{
				delete image;
				return false;
			}

			image->OverrideFormat( info.format );
		}
	}
	else if (inputFileExtension == L".tga")
	{
		ThWideString absPath = pipeline->MakeAbsolutePath(path);
		hr = LoadFromTGAFile( absPath.c_str(), &info, *image );
		
		if ( FAILED(hr) )
		{
			delete image;
			return false;
		}
	}
	else
	{
		// WIC shares the same filter values for mode and dither
		THOR_STATIC_ASSERT( WIC_FLAGS_DITHER == TEX_FILTER_DITHER, "WIC_FLAGS_* & TEX_FILTER_* should match" );
		THOR_STATIC_ASSERT( WIC_FLAGS_DITHER_DIFFUSION == TEX_FILTER_DITHER_DIFFUSION, "WIC_FLAGS_* & TEX_FILTER_* should match"  );
		THOR_STATIC_ASSERT( WIC_FLAGS_FILTER_POINT == TEX_FILTER_POINT, "WIC_FLAGS_* & TEX_FILTER_* should match"  );
		THOR_STATIC_ASSERT( WIC_FLAGS_FILTER_LINEAR == TEX_FILTER_LINEAR, "WIC_FLAGS_* & TEX_FILTER_* should match"  );
		THOR_STATIC_ASSERT( WIC_FLAGS_FILTER_CUBIC == TEX_FILTER_CUBIC, "WIC_FLAGS_* & TEX_FILTER_* should match"  );
		THOR_STATIC_ASSERT( WIC_FLAGS_FILTER_FANT == TEX_FILTER_FANT, "WIC_FLAGS_* & TEX_FILTER_* should match"  );

		ThWideString absPath = pipeline->MakeAbsolutePath(path);
		hr = LoadFromWICFile( absPath.c_str(), imageFilter, &info, *image );

		if ( FAILED(hr) )
		{
			delete image;
			return false;
		}
	}

	return true;
}

eImageProcessingResult::Val ThTextureToolsUtils::DecompressImage(const DirectX::ScratchImage* image, DirectX::ScratchImage** result)
{	
	const DirectX::TexMetadata& info = image->GetMetadata();

	if ( !IsCompressed( info.format ) )
		return eImageProcessingResult::NoOp;

	HRESULT hr;
	const Image* img = image->GetImage(0,0,0);
	THOR_ASSERT(img != 0, "No image data");
	size_t nimg = image->GetImageCount();

	ScratchImage *timage = new ScratchImage;
	
	if ( !timage )
	{
		return eImageProcessingResult::Failure;
	}

	hr = Decompress( img, nimg, info, DXGI_FORMAT_UNKNOWN /* picks good default */, *timage );

	if ( FAILED(hr) )
	{
		delete timage;
		return eImageProcessingResult::Failure;
	}

	const TexMetadata& tinfo = timage->GetMetadata();

	THOR_ASSERT(info.width == tinfo.width, "Invalid image header");
	THOR_ASSERT(info.height == tinfo.height, "Invalid image header");
	THOR_ASSERT(info.depth == tinfo.depth, "Invalid image header");
	THOR_ASSERT(info.arraySize == tinfo.arraySize, "Invalid image header");
	THOR_ASSERT(info.mipLevels == tinfo.mipLevels, "Invalid image header");
	THOR_ASSERT(info.miscFlags == tinfo.miscFlags, "Invalid image header");
	THOR_ASSERT(info.miscFlags2 == tinfo.miscFlags2, "Invalid image header");
	THOR_ASSERT(info.dimension == tinfo.dimension, "Invalid image header");

	*result = timage;

	return eImageProcessingResult::Success;
}

eImageProcessingResult::Val ThTextureToolsUtils::FlipRotateImage(const DirectX::ScratchImage* image, ThBool vertFlip, ThBool horFlip, DirectX::ScratchImage** result)
{
	if (!horFlip && !vertFlip)
		return eImageProcessingResult::NoOp;

	HRESULT hr;
	const DirectX::TexMetadata& info = image->GetMetadata();

	ScratchImage *timage = new ScratchImage;

	if ( !timage )
	{
		return eImageProcessingResult::Failure;
	}

	DWORD dwFlags = 0;

	if (horFlip)
		dwFlags |= TEX_FR_FLIP_HORIZONTAL;

	if (vertFlip)
		dwFlags |= TEX_FR_FLIP_VERTICAL;

	THOR_ASSERT(dwFlags != 0, "Invalid flags");

	hr = FlipRotate( image->GetImages(), image->GetImageCount(), image->GetMetadata(), dwFlags, *timage );

	if ( FAILED(hr) )
	{
		delete timage;
		return eImageProcessingResult::Failure;
	}

	const TexMetadata& tinfo = timage->GetMetadata();

	THOR_ASSERT(info.depth == tinfo.depth, "Invalid image header");
	THOR_ASSERT(info.arraySize == tinfo.arraySize, "Invalid image header");
	THOR_ASSERT(info.mipLevels == tinfo.mipLevels, "Invalid image header");
	THOR_ASSERT(info.miscFlags == tinfo.miscFlags, "Invalid image header");
	THOR_ASSERT(info.miscFlags2 == tinfo.miscFlags2, "Invalid image header");
	THOR_ASSERT(info.format == tinfo.format, "Invalid image header");
	THOR_ASSERT(info.dimension == tinfo.dimension, "Invalid image header");

	*result = timage;
	return eImageProcessingResult::Success;
}

eImageProcessingResult::Val ThTextureToolsUtils::ResizeImage(const DirectX::ScratchImage* image, ThU32 newWidth, ThU32 newHeight, ThU32 filter, DirectX::ScratchImage** result)
{
	const TexMetadata& info = image->GetMetadata();
	
	if ( info.width == newWidth && info.height == newHeight )
		return eImageProcessingResult::NoOp;

	HRESULT hr;
	ScratchImage *timage = new ScratchImage;

	if ( !timage )
	{
		return eImageProcessingResult::Failure;
	}

	hr = Resize( image->GetImages(), image->GetImageCount(), image->GetMetadata(), newWidth, newHeight, filter, *timage );

	if ( FAILED(hr) )
	{
		delete timage;
		return eImageProcessingResult::Failure;
	}

	const TexMetadata& tinfo = timage->GetMetadata();

	THOR_ASSERT(info.depth == tinfo.depth, "Invalid image header");
	THOR_ASSERT(info.arraySize == tinfo.arraySize, "Invalid image header");
	THOR_ASSERT(info.miscFlags == tinfo.miscFlags, "Invalid image header");
	THOR_ASSERT(info.miscFlags2 == tinfo.miscFlags2, "Invalid image header");
	THOR_ASSERT(info.format == tinfo.format, "Invalid image header");
	THOR_ASSERT(info.dimension == tinfo.dimension, "Invalid image header");

	*result = timage;
	return eImageProcessingResult::Success;
}

eImageProcessingResult::Val ThTextureToolsUtils::ConvertImage(const DirectX::ScratchImage* image, DXGI_FORMAT newFormat, ThU32 filter, DirectX::ScratchImage** result)
{
	const TexMetadata& info = image->GetMetadata();

	if ( info.format == newFormat || !IsCompressed( newFormat ) )
		return eImageProcessingResult::NoOp;
	
	HRESULT hr;
	ScratchImage *timage = new ScratchImage;

	if ( !timage )
	{
		return eImageProcessingResult::Failure;
	}

	hr = Convert( image->GetImages(), image->GetImageCount(), image->GetMetadata(), newFormat, filter, 0.5f, *timage );

	if ( FAILED(hr) )
	{
		delete timage;
		return eImageProcessingResult::Failure;
	}

	const TexMetadata& tinfo = timage->GetMetadata();

	THOR_ASSERT(info.width == tinfo.width, "Invalid image header");
	THOR_ASSERT(info.height == tinfo.height, "Invalid image header");
	THOR_ASSERT(info.depth == tinfo.depth, "Invalid image header");
	THOR_ASSERT(info.arraySize == tinfo.arraySize, "Invalid image header");
	THOR_ASSERT(info.mipLevels == tinfo.mipLevels, "Invalid image header");
	THOR_ASSERT(info.miscFlags == tinfo.miscFlags, "Invalid image header");
	THOR_ASSERT(info.miscFlags2 == tinfo.miscFlags2, "Invalid image header");
	THOR_ASSERT(info.dimension == tinfo.dimension, "Invalid image header");

	*result = timage;
	return eImageProcessingResult::Success;
}

eImageProcessingResult::Val ThTextureToolsUtils::PremultiplyAlpha(const DirectX::ScratchImage* image, DirectX::ScratchImage** result)
{
	const TexMetadata& info = image->GetMetadata();

	if (!HasAlpha( info.format ) || info.format == DXGI_FORMAT_A8_UNORM)
		return eImageProcessingResult::NoOp;


	if (info.IsPMAlpha())
	{
		return eImageProcessingResult::NoOp;
	}

	HRESULT hr;
	const Image* img = image->GetImage(0,0,0);
	THOR_ASSERT(img != 0, "No image data");
	size_t nimg = image->GetImageCount();

	ScratchImage *timage = new ScratchImage;
	if ( !timage )
	{
		return eImageProcessingResult::Failure;
	}

	hr = DirectX::PremultiplyAlpha(img, nimg, info, TEX_PMALPHA_DEFAULT, *timage);

	if (FAILED(hr))
	{
		delete timage;
		return eImageProcessingResult::Failure;
	}

	const TexMetadata& tinfo = timage->GetMetadata();

	THOR_ASSERT(info.width == tinfo.width, "Invalid image header");
	THOR_ASSERT(info.height == tinfo.height, "Invalid image header");
	THOR_ASSERT(info.depth == tinfo.depth, "Invalid image header");
	THOR_ASSERT(info.arraySize == tinfo.arraySize, "Invalid image header");
	THOR_ASSERT(info.mipLevels == tinfo.mipLevels, "Invalid image header");
	THOR_ASSERT(info.miscFlags == tinfo.miscFlags, "Invalid image header");
	THOR_ASSERT(info.miscFlags2 == tinfo.miscFlags2, "Invalid image header");
	THOR_ASSERT(info.dimension == tinfo.dimension, "Invalid image header");

	*result = timage;
	return eImageProcessingResult::Success;
}

eImageProcessingResult::Val ThTextureToolsUtils::CompressImage(const DirectX::ScratchImage* image, DXGI_FORMAT newFormat, DirectX::ScratchImage** result)
{
	const TexMetadata& info = image->GetMetadata();

	if (!IsCompressed(newFormat))
		return eImageProcessingResult::NoOp;

	HRESULT hr;
	const Image* img = image->GetImage(0,0,0);
	THOR_ASSERT(img != 0, "No image data");
	size_t nimg = image->GetImageCount();

	ScratchImage *timage = new ScratchImage();

	if ( !timage )
	{
		return eImageProcessingResult::Failure;
	}

	hr = Compress( img, nimg, info, newFormat, TEX_COMPRESS_DEFAULT, 0.5f, *timage );

	if ( FAILED(hr) )
	{
		delete timage;
		return eImageProcessingResult::Failure;
	}

	const TexMetadata& tinfo = timage->GetMetadata();

	THOR_ASSERT(info.width == tinfo.width, "Invalid image header");
	THOR_ASSERT(info.height == tinfo.height, "Invalid image header");
	THOR_ASSERT(info.depth == tinfo.depth, "Invalid image header");
	THOR_ASSERT(info.arraySize == tinfo.arraySize, "Invalid image header");
	THOR_ASSERT(info.mipLevels == tinfo.mipLevels, "Invalid image header");
	THOR_ASSERT(info.miscFlags == tinfo.miscFlags, "Invalid image header");
	THOR_ASSERT(info.miscFlags2 == tinfo.miscFlags2, "Invalid image header");
	THOR_ASSERT(info.dimension == tinfo.dimension, "Invalid image header");

	*result = timage;
	return eImageProcessingResult::Success;
}

eImageProcessingResult::Val ThTextureToolsUtils::GenerateMipmaps(const DirectX::ScratchImage* image, ThU32 mipLevels, ThU32 filter, DirectX::ScratchImage** result)
{
	ThBool nonpow2warn = false;

	HRESULT hr;
	const TexMetadata& info = image->GetMetadata();

	ScratchImage* curImage = const_cast<ScratchImage*>(image);
	ScratchImage* timage = 0;

	ThU32 curMipLevels = info.mipLevels;

	if (!ThTextureToolsUtils::IsPow2(info.width) || !ThTextureToolsUtils::IsPow2(info.height) || !ThTextureToolsUtils::IsPow2(info.depth) )
	{
		if ( info.dimension == TEX_DIMENSION_TEXTURE3D )
		{
			if ( !mipLevels )
			{
				mipLevels = 1;
			}
			else
			{
				return eImageProcessingResult::Failure;
			}
		}
		else if ( !mipLevels || info.mipLevels != 1 )
		{
			nonpow2warn = true;
		}
	}

	if ( (!mipLevels || info.mipLevels != mipLevels) && ( info.mipLevels != 1 ) )
	{
		// Mips generation only works on a single base image, so strip off existing mip levels
		timage = new ScratchImage();
		if ( !timage )
		{
			return eImageProcessingResult::Failure;
		}

		TexMetadata mdata = info;
		mdata.mipLevels = 1;
		hr = timage->Initialize( mdata );

		if ( FAILED(hr) )
		{
			delete timage;
			return eImageProcessingResult::Failure;
		}

		if ( info.dimension == TEX_DIMENSION_TEXTURE3D )
		{
			for( size_t d = 0; d < info.depth; ++d )
			{
				hr = CopyRectangle( *curImage->GetImage( 0, 0, d ), Rect( 0, 0, info.width, info.height ),
					*timage->GetImage( 0, 0, d ), TEX_FILTER_DEFAULT, 0, 0 );

				if ( FAILED(hr) )
				{
					delete timage;
					return eImageProcessingResult::Failure;
				}
			}
		}
		else
		{
			for( size_t i = 0; i < info.arraySize; ++i )
			{
				hr = CopyRectangle( *curImage->GetImage( 0, i, 0 ), Rect( 0, 0, info.width, info.height ),
					*timage->GetImage( 0, i, 0 ), TEX_FILTER_DEFAULT, 0, 0 );

				if ( FAILED(hr) )
				{
					delete timage;
					return eImageProcessingResult::Failure;
				}
			}
		}

		const TexMetadata& tinfo = timage->GetMetadata();
		curMipLevels = tinfo.mipLevels;

		curImage = timage;
		delete timage;
	}

	if ( !mipLevels || curMipLevels != mipLevels )
	{
		timage = new ScratchImage();

		if ( !timage )
		{			
			if (curImage != image)
				delete curImage;
			
			return eImageProcessingResult::Failure;
		}

		if ( info.dimension == TEX_DIMENSION_TEXTURE3D )
		{
			hr = GenerateMipMaps3D( curImage->GetImages(), curImage->GetImageCount(), curImage->GetMetadata(), filter, mipLevels, *timage );
		}
		else
		{
			hr = GenerateMipMaps( curImage->GetImages(), curImage->GetImageCount(), curImage->GetMetadata(), filter, mipLevels, *timage );
		}

		if ( FAILED(hr) )
		{			
			delete timage;
			
			if (curImage != image)
				delete curImage;
			
			return eImageProcessingResult::Failure;
		}

		const TexMetadata& tinfo = timage->GetMetadata();

		THOR_ASSERT(info.width == tinfo.width, "Invalid image header");
		THOR_ASSERT(info.height == tinfo.height, "Invalid image header");
		THOR_ASSERT(info.depth == tinfo.depth, "Invalid image header");
		THOR_ASSERT(info.arraySize == tinfo.arraySize, "Invalid image header");
		THOR_ASSERT(info.miscFlags == tinfo.miscFlags, "Invalid image header");
		THOR_ASSERT(info.miscFlags2 == tinfo.miscFlags2, "Invalid image header");
		THOR_ASSERT(info.dimension == tinfo.dimension, "Invalid image header");
	}
	else
		return eImageProcessingResult::NoOp;

	if ( nonpow2warn )
		THOR_WRN("Not all feature levels support non-power-of-2 textures with mipmaps")(textureToolsLogTag);

	if (curImage != image)
		delete curImage;

	*result = timage;

	return eImageProcessingResult::Success;
}

}