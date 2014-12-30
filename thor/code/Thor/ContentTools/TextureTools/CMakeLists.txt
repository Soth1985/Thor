##########################################################################
# TextureTools														 #
##########################################################################
file(GLOB TextureTools_CPP "*.cpp")
file(GLOB TextureTools_H "*.h")

set(TextureTools_Src ${TextureTools_CPP} ${TextureTools_H})

set(TextureToolsProtocol_Src 
		${PROTOCOL_PATH}/TextureToolsProtocol/TextureToolsProtocol.dff
		${PROTOCOL_PATH}/TextureToolsProtocol/TextureToolsProtocol.dfp
		${PROTOCOL_PATH}/TextureToolsProtocol/TextureToolsProtocol.h
		${PROTOCOL_PATH}/TextureToolsProtocol/TextureToolsProtocol.cpp)

set(TextureTools_Src ${TextureTools_Src} ${TextureToolsProtocol_Src})

source_group( Protocol FILES ${TextureToolsProtocol_Src} )

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_CONTENT_PIPELINE_IMPORT)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_definitions(-DTHOR_TEXTURE_TOOLS_EXPORT)
	add_library(TextureTools SHARED ${TextureTools_Src})
	target_link_libraries(	TextureTools
							debug Framework_d
							debug ContentPipeline_d
							debug DirectXTex_d
							optimized Framework
							optimized ContentPipeline
							optimized DirectXTex)
	set(TextureToolsInstallTargets ${TextureToolsInstallTargets} TextureTools)
	set_target_properties(TextureTools PROPERTIES FOLDER ContentTools)
elseif(THOR_BUILD_STATIC)
	add_library(LibTextureTools STATIC ${TextureTools_Src})
	target_link_libraries(	LibTextureTools
							debug LibFramework_d
							debug LibContentPipeline_d
							debug DirectXTex_d
							optimized LibFramework
							optimized LibContentPipeline
							optimized DirectXTex)
	set(TextureToolsInstallTargets ${TextureToolsInstallTargets} LibTextureTools)
	set_target_properties(LibTextureTools PROPERTIES FOLDER ContentTools)
endif()

thor_install( TextureToolsInstallTargets )