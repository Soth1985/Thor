#include <Thor/ContentTools/ContentPipeline/ThContentPipeline.h>
#include <Thor/Framework/DataModel/ThDataModel.h>
#include <Thor/Framework/ThStringUtilities.h>
#include <filesystem>
#include <cryptopp/dll.h>
#include <cryptopp/base64.h>

using namespace Thor::ContentToolsProtocol;
namespace fs = std::tr2::sys;

namespace Thor
{

THOR_REG_TYPE(ThContentPipeline, THOR_TYPELIST_1(ThiObject));
//Settings
//Input
//Intermediate
//Output
static const ThWchar* gIntermediateDir = L"Intermediate";
static const ThWchar* gSettingsDir = L"Settings";
static const ThWchar* gInputDir = L"Input";
static const ThWchar* gOutputDir = L"Output";
static const ThWchar* gSettingsFile = L"Settings/settings.xml";
static const ThWchar* gAllConfigurations = L"*";
static const ThWchar* gMetadataExt = L".cpmd";

ThContentPipeline::ThContentPipeline()
{
	m_Filesystem = ThFileSystemFactory::Instance().CreateFileSystem( eFileSystemType::PhysFS );
	m_Root = new TheContentPipelineRoot();
	m_ContentDb = new TheContentDb();
}

ThBool ThContentPipeline::RegisterContentImporter(ThiContentImporterPtr importer)
{
	const ThiType* importerType = importer->GetType();

	if (!m_Importers.Insert(importerType, importer))
	{
		THOR_ERR("Importer of type %s is already registered, only one importer per type is allowed.")(contentPipelineLogTag, importerType->GetName());
		return false;
	}

	//find rules for the importer in this configuration, or create default ones
	auto* rl = m_Root->ImportRules.Find(importer->GetType()->GetName());
	TheImportRulesPtr rules;

	if (rl)
	{
		for (ThSize i = 0; i < rl->GetSize(); ++i)
		{
			TheImportRulesPtr curRules = rl->GetItemValue(i);

			if (curRules->ConfigurationName == m_ConfigurationName)
			{
				rules = curRules;
				break;
			}
			else if (curRules->ConfigurationName == gAllConfigurations)
			{
				rules = curRules;
			}
		}
	}

	if(!rules)
	{
		typedef TheContentPipelineRoot::ImportRulesTypename::ItemType ImportRulesItemType;
		ImportRulesItemType newRules;
		rules = importer->GetImportRules();
		newRules.PushBack(rules);
		m_Root->ImportRules.SetItemValue(importer->GetType()->GetName(), newRules);
		THOR_INF("Importer %s has no rules assigned for the current configuration %ls, default ones are created.")(contentPipelineLogTag, importer->GetType()->GetName(), m_ConfigurationName.c_str());
	}

	return true;
}

ThBool ThContentPipeline::UnRegisterContentImporter(ThiContentImporterPtr importer)
{
	return m_Importers.Erase(importer->GetType());
}

ThBool ThContentPipeline::SetWorkingDirectory(const ThWideString& path)
{
	fs::wpath boostPath(path);

	ThString pathUtf8 = ThStringUtilities::WideStringToUtf8(boostPath.string());

	if (!fs::exists(boostPath))
	{
		THOR_INF_W("Directory %ls does not exist, attempting to create.")(contentPipelineLogTag, path.c_str());
		
		if (!fs::create_directories(boostPath))
		{
			THOR_ERR("Failed to create directory.")(contentPipelineLogTag);
			return false;
		}
		else
			THOR_INF("Directory created.")(contentPipelineLogTag);
	}

	THOR_INF_W("Setting working directory to %ls.")(contentPipelineLogTag, path.c_str());
	m_Filesystem->MountDir(pathUtf8, ThString(), eMountMode::FullAccess);

	THOR_INF_W("Loading settings from %ls.")(contentPipelineLogTag, gSettingsFile);

	ThiFileStreamPtr config;
	
	config = m_Filesystem->OpenFile(ThStringUtilities::WideStringToUtf8(gSettingsFile), eStreamMode::ReadMode);

	if (config)
	{
		ThXmlArchiveReader reader;
		m_Root = ThiArchiveUtils::LoadSingleEntity<TheContentPipelineRoot>(reader, config);

		if (!m_Root)
		{
			THOR_ERR("Failed to load pipeline settings.")(contentPipelineLogTag);
			return false;
		}
	}
	else
	{
		THOR_INF_W("%ls does not exist, using default settings.")(contentPipelineLogTag, gSettingsFile);
	}

	m_WorkingDirectory = path;

	const wchar_t* directoriesToCreate[] = {gSettingsDir, gIntermediateDir, gInputDir, gOutputDir};

	for (ThSize i = 0; i < sizeof (directoriesToCreate) / sizeof (wchar_t*); ++i)
	{
		if (!fs::exists(fs::wpath(MakeAbsolutePath(directoriesToCreate[i]))))
		{
			if (!CreateDirectory(directoriesToCreate[i]))
			{
				m_WorkingDirectory.clear();
				return false;
			}
		}
	}

	return true;
}

const ThWideString& ThContentPipeline::GetWorkingDirectory()const
{
	return m_WorkingDirectory;
}

ThWideString ThContentPipeline::GetIntermediateDirectory()const
{
	return CombinePath(gIntermediateDir, m_ConfigurationName);
}

ThWideString ThContentPipeline::GetOutputDirectory()const
{
	return CombinePath(gOutputDir, m_ConfigurationName);
}

const ThWideString& ThContentPipeline::GetConfigurationName()const
{
	return m_ConfigurationName;
}

ThBool ThContentPipeline::SetConfigurationName(const ThWideString& configuration)
{
	if(m_WorkingDirectory.empty())
	{
		THOR_ERR("Set working directory before choosing configuration.")(contentPipelineLogTag);
		return false;
	}

	THOR_INF_W("Setting configuration name to %ls.")(contentPipelineLogTag, configuration.c_str());	

	ThWideString intermediateDir = gIntermediateDir;
	intermediateDir = CombinePath(intermediateDir, configuration);

	if (!fs::exists(fs::wpath(intermediateDir)))
	{
		if (!CreateDirectory(intermediateDir))
		{
			return false;
		}
	}

	ThWideString outputDir = gOutputDir;
	outputDir = CombinePath(outputDir, configuration);

	if (!fs::exists(fs::wpath(outputDir)))
	{
		if (!CreateDirectory(outputDir))
		{
			return false;
		}
	}

	if (m_ContentDb)
	{
		m_ContentDb = 0;
	}

	m_ConfigurationName = configuration;

	return true;
}

ThWideString ThContentPipeline::CombinePath(const ThWideString& path1, const ThWideString& path2)const
{
	fs::wpath result(path1);

	result /= path2;

	ThWideString str = result.string();

	NormalizePath(str);

	return str;
}

ThWideString ThContentPipeline::ReplaceExtension(const ThWideString& path, const ThWideString& extension)const
{
	fs::wpath temp(path);

	return temp.replace_extension(extension).string();
}

ThWideString ThContentPipeline::GetFilename(const ThWideString& path)const
{
	fs::wpath temp(path);

	return temp.replace_extension().string();
}

ThWideString ThContentPipeline::GetExtension(const ThWideString& path)const
{
	fs::wpath temp(path);

	return temp.extension();
}

ThWideString ThContentPipeline::ConvertToPathHelper(const ThWideString& path, const ThWideString& tgtDir)const
{
	ThWideString result;
	ThWideString relPath;
	ThWideString outputDir = CombinePath(gOutputDir, m_ConfigurationName);
	ThWideString intermedDir = CombinePath(gIntermediateDir, m_ConfigurationName);

	if (path.find(gInputDir) == 0)
	{
		relPath = path.substr(wcslen(gInputDir));
	}
	else if (path.find(outputDir) == 0)
	{
		relPath = path.substr(outputDir.length());
	}
	else if (path.find(intermedDir) == 0)
	{
		relPath = path.substr(intermedDir.length());
	}
	else
		relPath = path;		

	result = CombinePath(tgtDir, relPath);

	return result;
}

ThWideString ThContentPipeline::ConvertToOutputPath(const ThWideString& path)const
{
	return ConvertToPathHelper(path, GetOutputDirectory());
}

ThWideString ThContentPipeline::ConvertToIntermediatePath(const ThWideString& path)const
{
	return ConvertToPathHelper(path, GetIntermediateDirectory());
}

ThWideString ThContentPipeline::GetDirectory(const ThWideString& path)const
{
	fs::wpath temp(path);

	ThWideString result = temp.remove_filename().string();

	NormalizePath(result);

	return result;
}

void ThContentPipeline::NormalizePath(ThWideString& path)const
{
	for (ThSize i = 0; i < path.length(); ++i)
	{
		if (path[i] == L'\\')
			path[i] = '/';
	}
}

ThWideString ThContentPipeline::MakeAbsolutePath(const ThWideString& relativePath)const
{
	return CombinePath(m_WorkingDirectory, relativePath);
}

ThBool ThContentPipeline::CreateDirectory(const ThWideString& relativePath)const
{
	ThWideString absolutePath = MakeAbsolutePath(relativePath);

	if (!fs::create_directories(fs::wpath(absolutePath)))
	{
		THOR_ERR_W("Failed to create directory %ls.")(contentPipelineLogTag, absolutePath.c_str());
		return false;
	}

	return true;
}

ThBool ThContentPipeline::DeleteDirectory(const ThWideString& relativePath)const
{
	ThWideString absolutePath = MakeAbsolutePath(relativePath);
	fs::remove_all(fs::wpath(absolutePath));

	/*if (error)
	{
		THOR_ERR_W("Failed to delete directory %ls, message = %s.")(contentPipelineLogTag, absolutePath.c_str(), error.message().c_str());
		return false;
	}*/

	return true;
}

ThiFileSystemPtr ThContentPipeline::GetFilesystem()
{
	return m_Filesystem;
}

ThBool ThContentPipeline::FileExists(const ThWideString& path)const
{
	ThWideString absAssetPath = MakeAbsolutePath(path);

	if (!fs::exists(fs::wpath(absAssetPath)))
	{
		return false;
	}

	if (!fs::is_regular_file(fs::wpath(absAssetPath)))
	{
		return false;
	}

	return true;
}

void ThContentPipeline::Import()
{
	if (!IsInitialized())
		return;

	ThString configurationName = ThStringUtilities::WideStringToUtf8(m_ConfigurationName);

	//sort importers by priority
	ThVector<ThiContentImporterPtr> sortedImporters;
	sortedImporters.Reserve(m_Importers.Size());

	for (ThSize i = 0; i < m_Importers.Size(); ++i)
	{
		sortedImporters.PushBack(m_Importers.GetItem(i).Value());
	}

	std::sort(sortedImporters.Begin(), sortedImporters.End(), 
			[](const ThiContentImporterPtr& a, const ThiContentImporterPtr& b)->bool
			{
				return a->GetPriority() < b->GetPriority();
			}
	);

	for (ThSize i = 0; i < sortedImporters.Size(); ++i)
	{
		ThiContentImporterPtr importer = sortedImporters[i];
		// do import
		importer->Import(this);
	}
}

void ThContentPipeline::CollectInputFilesWithExtensions(const ThHashSet<ThWideString>& extensions, ThHashSet<ThWideString>& result)
{
	auto f = [&](const ThWideString& path)
	{
		ThWideString extension = GetExtension(path);

		if (extensions.Find(extension) != extensions.End())
			result.Insert(path);
	};

	RecursiveDirectoryScan(gInputDir, f);
}

void ThContentPipeline::RecursiveDirectoryScan(const ThWideString& dir, std::tr1::function<void(const ThWideString&)> func)
{
	ThiFileSystem::StringList contents = m_Filesystem->Enumerate(ThStringUtilities::WideStringToUtf8(dir));

	for (ThSize i = 0; i < contents.size(); ++i)
	{
		ThWideString curPath = CombinePath(dir, ThStringUtilities::Utf8ToWideString(contents[i]));
		if(m_Filesystem->IsDirectory(ThStringUtilities::WideStringToUtf8(curPath)))
		{
			RecursiveDirectoryScan(curPath, func);
		}
		else
		{
			func(curPath);
		}
	}	
}

void ThContentPipeline::CleanIntermediateDir()
{
	ThWideString intermediateDir = CombinePath(gIntermediateDir, m_ConfigurationName);

	if( DeleteDirectory(intermediateDir) )
		CreateDirectory(intermediateDir);
	else
		THOR_ERR_W("Failed to clean intermediate directory %ls .")(contentPipelineLogTag, intermediateDir.c_str());
}

void ThContentPipeline::CleanOutputDir()
{
	ThWideString outputDir = CombinePath(gOutputDir, m_ConfigurationName);

	if( DeleteDirectory(outputDir) )
		CreateDirectory(outputDir);
	else
		THOR_ERR_W("Failed to clean output directory %ls .")(contentPipelineLogTag, outputDir.c_str());
}

void ThContentPipeline::SaveSettings()
{
	ThiFileStreamPtr file = m_Filesystem->OpenFile(ThStringUtilities::WideStringToUtf8(gSettingsFile), eStreamMode::WriteMode, eFileWriteMode::Truncate);

	if (file)
	{
		ThXmlArchiveWriter writer;
		ThiArchiveUtils::SaveSingleEntity(m_Root, writer, ThiDataStreamPtr(file));
	}
	else
		THOR_ERR_W("Failed to save settings.")(contentPipelineLogTag);
}

void ThContentPipeline::SaveDb()
{

}

ThiType* ThContentPipeline::GetType(void)const
{
	return ThType<ThContentPipeline>::Instance();
}

ThBool ThContentPipeline::IsInitialized()const
{
	if (m_WorkingDirectory.empty())
	{
		THOR_ERR("ContentPipeline is not initialized, working directory is not set.")(contentPipelineLogTag);
		return false;
	}

	if (m_ConfigurationName.empty())
	{
		THOR_ERR("ContentPipeline is not initialized, configuration name is not set.")(contentPipelineLogTag);
		return false;
	}

	return true;
}

ThString ThContentPipeline::ComputeFileHash(const ThWideString& filePath)
{
	ThString result;
	result.reserve(65);

	CryptoPP::SHA256 hash;

	CryptoPP::FileSource pipeline(MakeAbsolutePath(filePath).c_str(), true,
		new CryptoPP::HashFilter(hash,
		new CryptoPP::Base64Encoder (
		new CryptoPP::StringSink(result))));

	return result;
}

ThBool ThContentPipeline::CheckMetadata(const ThWideString& filePath, const MetadataPairs& items)const
{	
	TheFileMetadataPtr metadata = GetImportedFileMetadata(filePath);

	TheFileMetadataPtr curMetadata = CreateMetadata(items);

	if (metadata)
	{
		if (metadata->Equals(curMetadata))
		{
			return true;
		}
	}

	return false;
}

void ThContentPipeline::WriteImportedFileMetadata(const ThWideString& filePath, TheFileMetadataPtr metadata)
{
	ThWideString mdPath = GetMetadataPath(filePath);
	
	if (!CreateDirectory(GetDirectory(mdPath)))
		return;

	ThiFileStreamPtr file = m_Filesystem->OpenFile(ThStringUtilities::WideStringToUtf8(mdPath), eStreamMode::WriteMode, eFileWriteMode::Truncate);

	if (file)
	{
		ThXmlArchiveWriter writer;
		ThiArchiveUtils::SaveSingleEntity(metadata, writer, ThiDataStreamPtr(file));
	}
	else
		THOR_ERR_W("Failed to write metadata for asset %ls")(contentPipelineLogTag, filePath.c_str());
}

TheFileMetadataPtr ThContentPipeline::CreateMetadata(const MetadataPairs& items)const
{
	TheFileMetadataPtr metadata = new TheFileMetadata();

	for(ThSize i = 0; i < items.Size(); ++i)
	{
		ThsFileMetadataItem item;
		item.Hash = items[i].First();
		item.CachedOptions = items[i].Second();
		metadata->Items.PushBackItem(item);
	}

	return metadata;
}

TheFileMetadataPtr ThContentPipeline::GetImportedFileMetadata(const ThWideString& filePath)const
{
	TheFileMetadataPtr metadata;

	ThiFileStreamPtr metadataFile = m_Filesystem->OpenFile(ThStringUtilities::WideStringToUtf8(GetMetadataPath(filePath)), eStreamMode::ReadMode); 

	if (metadataFile)
	{
		ThXmlArchiveReader reader;
		metadata = ThiArchiveUtils::LoadSingleEntity<TheFileMetadata>(reader, metadataFile);
	}

	return metadata;
}

ThWideString ThContentPipeline::GetMetadataPath(const ThWideString& assetPath)const
{
	ThWideString temp = ConvertToIntermediatePath(assetPath);
	return ReplaceExtension(temp, gMetadataExt);
}

ContentToolsProtocol::TheContentLibraryPtr ThContentPipeline::GetContentLibrary(ThiType* libraryType)
{
	if (!libraryType->IsChildOf(TypeOf<TheContentLibrary>()))
	{
		THOR_ERR("%s is not a content library type")(contentPipelineLogTag, libraryType->GetName());
		return 0;
	}

	for (ThSize i = 0; i < m_ContentDb->ContentLibraries.GetSize(); ++i)
	{
		if(m_ContentDb->ContentLibraries.GetItemValue(i)->GetType() == libraryType)
			return m_ContentDb->ContentLibraries.GetItemValue(i);
	}

	TheContentLibraryPtr newLibrary = (TheContentLibrary*)libraryType->CreateObject();

	m_ContentDb->ContentLibraries.PushBackItemValue(newLibrary);

	return newLibrary;
}

ContentToolsProtocol::TheContentNodePtr ThContentPipeline::CreateContentNode(ThiType* nodeType)
{
	if (!nodeType->IsChildOf(TypeOf<TheContentNode>()))
	{
		THOR_ERR("%s is not a content node type")(contentPipelineLogTag, nodeType->GetName());
		return 0;
	}

	TheContentNodePtr result = (TheContentNode*)nodeType->CreateObject();

	return result;
}

}