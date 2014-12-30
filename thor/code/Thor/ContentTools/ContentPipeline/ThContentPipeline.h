#pragma once

#include <Thor/Framework/Containers/ThHashMap.h>
#include <Thor/Framework/Containers/ThHashSet.h>
#include <Thor/Framework/FileSystem/LibFileSystem.h>
#include <Thor/ContentTools/ContentPipeline/ThContentPipelineFwd.h>
#include <Thor/ContentTools/ContentPipeline/ThiContentImporter.h>
#include <Thor/Protocol/ThContentPipelineProtocol/ThContentPipelineProtocol.h>

namespace Thor
{

class THOR_CONTENT_PIPELINE_DLL ThContentPipeline : public ThiObject
{
public:

	typedef ThVector< ThPair<ThString, ContentToolsProtocol::TheImporterOptionsPtr> > MetadataPairs;

	ThContentPipeline();

	ThBool RegisterContentImporter(ThiContentImporterPtr importer);
	ThBool UnRegisterContentImporter(ThiContentImporterPtr importer);
	ThBool SetWorkingDirectory(const ThWideString& path);
	const ThWideString& GetWorkingDirectory()const;
	ThWideString GetIntermediateDirectory()const;
	ThWideString GetOutputDirectory()const;
	const ThWideString& GetConfigurationName()const;
	ThBool SetConfigurationName(const ThWideString& configuration);
	ThiFileSystemPtr GetFilesystem();
	void Import();
	void CleanIntermediateDir();
	void CleanOutputDir();
	void RecursiveDirectoryScan(const ThWideString& dir, std::tr1::function<void(const ThWideString&)> func);
	void CollectInputFilesWithExtensions(const ThHashSet<ThWideString>& extensions, ThHashSet<ThWideString>& result);

	ThString ComputeFileHash(const ThWideString& filePath);
	ThWideString GetMetadataPath(const ThWideString& assetPath)const;
	void WriteImportedFileMetadata(const ThWideString& filePath, ContentToolsProtocol::TheFileMetadataPtr metadata);
	ContentToolsProtocol::TheFileMetadataPtr CreateMetadata(const MetadataPairs& items)const;
	ThBool CheckMetadata(const ThWideString& filePath, const MetadataPairs& items)const;
	ContentToolsProtocol::TheFileMetadataPtr GetImportedFileMetadata(const ThWideString& filePath)const;

	ContentToolsProtocol::TheContentPipelineRootPtr& GetRoot();
	ContentToolsProtocol::TheContentDbPtr& GetContentDb();

	template<class LibT>
	ThRefPtr<LibT> GetContentLibrary()
	{
		ContentToolsProtocol::TheContentLibraryPtr lib = GetContentLibrary(TypeOf<LibT>());

		if (lib)
			return (LibT*)lib.GetPtr();
		else
			return 0;
	}

	ContentToolsProtocol::TheContentLibraryPtr GetContentLibrary(ThiType* libraryType);

	template<class NodeT>
	ThRefPtr<NodeT> CreateContentNode()
	{
		ContentToolsProtocol::TheContentNodePtr node = CreateContentNode(TypeOf<NodeT>());

		if (node)
			return (NodeT*)node.GetPtr();
		else
			return 0;
	}

	ContentToolsProtocol::TheContentNodePtr CreateContentNode(ThiType* nodeType);

	virtual ThiType* GetType(void)const;
	void SaveSettings();
	void SaveDb();

	ThBool CreateDirectory(const ThWideString& relativePath)const;
	ThBool FileExists(const ThWideString& path)const;
	ThWideString CombinePath(const ThWideString& path1, const ThWideString& path2)const;
	ThWideString ReplaceExtension(const ThWideString& path, const ThWideString& extension)const;
	ThWideString GetFilename(const ThWideString& path)const;
	ThWideString GetExtension(const ThWideString& path)const;
	ThWideString GetDirectory(const ThWideString& path)const;
	ThWideString ConvertToIntermediatePath(const ThWideString& path)const;
	ThWideString ConvertToOutputPath(const ThWideString& path)const;
	ThWideString MakeAbsolutePath(const ThWideString& relativePath)const;
	ThBool DeleteDirectory(const ThWideString& relativePath)const;
	void NormalizePath(ThWideString& path)const;
	
private:

	ThBool IsInitialized()const;
	ThWideString ConvertToPathHelper(const ThWideString& path, const ThWideString& tgtDir)const;

	typedef ThHashMap<const ThiType*, ThiContentImporterPtr> ImporterMap;

	ThWideString m_WorkingDirectory;
	ThWideString m_ConfigurationName;
	ImporterMap m_Importers;
	mutable ThiFileSystemPtr m_Filesystem;
	ContentToolsProtocol::TheContentPipelineRootPtr m_Root;
	ContentToolsProtocol::TheContentDbPtr m_ContentDb;
};

}