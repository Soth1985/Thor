#pragma once

#include <Thor/ContentTools/ContentPipeline/ThContentPipelineFwd.h>
#include <Thor/Framework/Containers/ThHashSet.h>
#include <Thor/Protocol/ThContentPipelineProtocol/ThContentPipelineProtocol.h>

namespace Thor
{

class THOR_CONTENT_PIPELINE_DLL ThiContentImporter : public ThiObject
{
public:

	ThiContentImporter();

	void SetPriority(ThSize priority);
	ThSize GetPriority()const;
	virtual ContentToolsProtocol::TheImportRulesPtr GetImportRules()const = 0;
	virtual void SetImportRules(const ContentToolsProtocol::TheImportRulesPtr& rule) = 0;
	virtual void Import(ThContentPipeline* pipeline) = 0;
	virtual ThHashSet<ThWideString> GetSupportedFileExtensions()const = 0;

private:

	ThSize m_Priority;
};

}