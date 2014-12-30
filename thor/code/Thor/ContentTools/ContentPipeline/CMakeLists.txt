##########################################################################
# ContentPipeline														 #
##########################################################################
file(GLOB ContentPipeline_CPP "*.cpp")
file(GLOB ContentPipeline_H "*.h")

set(ContentPipeline_Src ${ContentPipeline_CPP} ${ContentPipeline_H})

set(ContentPipelineProtocol_Src 
		${PROTOCOL_PATH}/ThContentPipelineProtocol/ThContentPipelineProtocol.dff
		${PROTOCOL_PATH}/ThContentPipelineProtocol/ThContentPipelineProtocol.dfp
		${PROTOCOL_PATH}/ThContentPipelineProtocol/ThContentPipelineProtocol.h
		${PROTOCOL_PATH}/ThContentPipelineProtocol/ThContentPipelineProtocol.cpp)

set(ContentPipeline_Src ${ContentPipeline_Src} ${ContentPipelineProtocol_Src})

source_group( Protocol FILES ${ContentPipelineProtocol_Src} )


if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_definitions(-DTHOR_MATH_IMPORT)
	add_definitions(-DTHOR_CONTENT_PIPELINE_EXPORT)
	add_definitions(-DBOOST_FILESYSTEM_DYN_LINK)
	add_library(ContentPipeline SHARED ${ContentPipeline_Src})
	target_link_libraries(	ContentPipeline
							debug Framework_d
							debug ThorMath_d
							debug cryptopp_d
							optimized Framework
							optimized ThorMath
							optimized boost_filesystem-mt
							optimized boost_system-mt
							optimized cryptopp)
	set(ContentPipelineInstallTargets ${ContentPipelineInstallTargets} ContentPipeline)
	set_target_properties(ContentPipeline PROPERTIES FOLDER ContentTools)
elseif(THOR_BUILD_STATIC)
	add_library(LibContentPipeline STATIC ${ContentPipeline_Src})
	target_link_libraries(	LibContentPipeline
							debug LibFramework_d
							debug LibThorMath_d
							debug cryptlib_d
							optimized LibFramework
							optimized LibThorMath
							optimized libboost_filesystem-mt
							optimized libboost_system-mt
							optimized cryptlib)
	set(ContentPipelineInstallTargets ${ContentPipelineInstallTargets} LibContentPipeline)
	set_target_properties(LibContentPipeline PROPERTIES FOLDER ContentTools)
endif()

thor_install( ContentPipelineInstallTargets )