##########################################################################
# ContentPipelineStandAlone                                       		 #
##########################################################################
file(GLOB ContentPipelineStandAlone_CPP "*.cpp")
file(GLOB ContentPipelineStandAlone_H "*.h")

set(ContentPipelineStandAlone_Src ${ContentPipelineStandAlone_CPP} ${ContentPipelineStandAlone_H})

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_CONTENT_PIPELINE_IMPORT)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_executable(ContentPipelineStandAlone ${ContentPipelineStandAlone_Src})
	target_link_libraries(	ContentPipelineStandAlone
							debug ContentPipeline_d
							debug Framework_d
							debug TextureTools_d	
							optimized ContentPipeline
							optimized Framework
							optimized TextureTools)
	set(ContentPipelineStandAloneInstallTargets ${ContentPipelineStandAloneInstallTargets} ContentPipelineStandAlone)
	set_target_properties(ContentPipelineStandAlone PROPERTIES FOLDER ContentTools)
elseif(THOR_BUILD_STATIC)
	add_executable(ContentPipelineStandAlone ${ContentPipelineStandAlone_Src})
	target_link_libraries(	ContentPipelineStandAloneStatic
							debug LibContentPipeline_d	
							debug LibFramework_d
							debug LibTextureTools_d	
							optimized LibContentPipeline
							optimized LibFramework
							optimized LibTextureTools)
	set(ContentPipelineStandAloneInstallTargets ${ContentPipelineStandAloneInstallTargets} ContentPipelineStandAlone)
	set_target_properties(ContentPipelineStandAloneStatic PROPERTIES FOLDER ContentTools)
endif()

thor_install( ContentPipelineStandAloneInstallTargets )