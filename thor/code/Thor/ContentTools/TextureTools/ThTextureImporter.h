#pragma once

#include <Thor/ContentTools/TextureTools/ThTextureToolsFwd.h>
#include <Thor/ContentTools/ContentPipeline/ThiContentImporter.h>
#include <Thor/Protocol/TextureToolsProtocol/TextureToolsProtocol.h>

namespace Thor
{

class THOR_TEXTURE_TOOLS_DLL ThTextureImporter : public ThiContentImporter
{
public:

	ThTextureImporter();

	virtual ThHashSet<ThWideString> GetSupportedFileExtensions()const;
	virtual ContentToolsProtocol::TheImportRulesPtr GetImportRules()const;
	virtual void SetImportRules(const ContentToolsProtocol::TheImportRulesPtr& rule);
	virtual void Import(ThContentPipeline* pipeline);
	virtual ThiType* GetType()const;

private:

	ThBool PreprocessTextureArrayImportOptions(ThContentPipeline* pipeline, ContentToolsProtocol::TheTextureArrayImportOptionsPtr options);
	ThBool MakeOutputPath(ThContentPipeline* pipeline, ThBool isArray, const ThWideString& inputPath, const ContentToolsProtocol::TheTextureImportOptionsPtr& options, ThWideString& outputPath);

	ContentToolsProtocol::TheTextureToolsRulesPtr m_Rules;
};

}