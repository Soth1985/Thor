##########################################################################
# GeometryTools													 #
##########################################################################
file(GLOB GeometryTools_CPP "*.cpp")
file(GLOB GeometryTools_H "*.h")

set(GeometryTools_Src ${GeometryTools_CPP} ${GeometryTools_H})

set(GeometryToolsProtocol_Src 
		${PROTOCOL_PATH}/GeometryToolsProtocol/GeometryToolsProtocol.dff
		${PROTOCOL_PATH}/GeometryToolsProtocol/GeometryToolsProtocol.dfp
		${PROTOCOL_PATH}/GeometryToolsProtocol/GeometryToolsProtocol.h
		${PROTOCOL_PATH}/GeometryToolsProtocol/GeometryToolsProtocol.cpp)

set(GeometryTools_Src ${GeometryTools_Src} ${GeometryToolsProtocol_Src})

source_group( Protocol FILES ${GeometryToolsProtocol_Src} )

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_CONTENT_PIPELINE_IMPORT)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_definitions(-DTHOR_GEOMETRY_TOOLS_EXPORT)
	add_library(GeometryTools SHARED ${GeometryTools_Src})
	target_link_libraries(	GeometryTools
							debug ContentPipeline_d
							debug Framework_d
							debug libfbxsdk-md_d
							optimized ContentPipeline
							optimized Framework
							optimized libfbxsdk-md)
	set(GeometryToolsInstallTargets ${GeometryToolsInstallTargets} GeometryTools)
	set_target_properties(GeometryTools PROPERTIES FOLDER ContentTools)
elseif(THOR_BUILD_STATIC)
	add_library(LibGeometryTools STATIC ${GeometryTools_Src})
	target_link_libraries(	LibGeometryTools
							debug LibContentPipeline_d
							debug LibFramework_d
							debug libfbxsdk-md_d
							optimized LibContentPipeline
							optimized LibFramework
							optimized libfbxsdk-md)
	set(GeometryToolsInstallTargets ${GeometryToolsInstallTargets} LibGeometryTools)
	set_target_properties(LibGeometryTools PROPERTIES FOLDER ContentTools)
endif()

thor_install( GeometryToolsInstallTargets )