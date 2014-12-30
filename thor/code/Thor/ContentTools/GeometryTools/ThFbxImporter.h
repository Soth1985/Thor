#pragma once

#include <Thor/ContentTools/GeometryTools/ThGeometryToolsFwd.h>
#include <Thor/ContentTools/ContentPipeline/ThiContentImporter.h>
#include <Thor/Protocol/GeometryToolsProtocol/GeometryToolsProtocol.h>

namespace Thor
{

class THOR_GEOMETRY_TOOLS_DLL ThFbxImporter : public ThiContentImporter
{
public:

	ThFbxImporter();

	virtual ThHashSet<ThWideString> GetSupportedFileExtensions()const;
	virtual ContentToolsProtocol::TheImportRulesPtr GetImportRules()const;
	virtual void SetImportRules(const ContentToolsProtocol::TheImportRulesPtr& rule);
	virtual void Import(ThContentPipeline* pipeline);
	virtual ThiType* GetType()const;

private:

	ContentToolsProtocol::TheGeometryToolsRulesPtr m_Rules;
};

}