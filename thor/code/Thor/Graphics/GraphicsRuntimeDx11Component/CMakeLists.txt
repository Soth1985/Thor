##########################################################################
# GraphicsRuntimeDx11Component                                           #
##########################################################################
file(GLOB GraphicsRuntimeDx11Component_CPP "*.cpp")
file(GLOB GraphicsRuntimeDx11Component_H "*.h")

set(GraphicsRuntimeDx11Component_Src ${GraphicsRuntimeDx11Component_CPP} ${GraphicsRuntimeDx11Component_H})
include_directories(${DIRECTX_SDK_PATH}/include)

if(WIN32)

	if (THOR_X32)
		link_directories( ${DIRECTX_SDK_PATH}/lib/x86)
	endif()
	
	if (THOR_X64)
		link_directories( ${DIRECTX_SDK_PATH}/lib/x64)
	endif()
	
endif()

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_definitions(-DTHOR_MATH_IMPORT)
	add_definitions(-DTHOR_GRAPHICS_RUNTIME_DX11_EXPORT)
	add_library(GraphicsRuntimeDx11Component SHARED ${GraphicsRuntimeDx11Component_Src})
	target_link_libraries(	GraphicsRuntimeDx11Component
							debug Framework_d
							debug ThorMath_d
							debug d3dx11d.lib
							optimized Framework
							optimized ThorMath
							optimized d3dx11.lib)
	target_link_libraries(GraphicsRuntimeDx11Component d3dcompiler.lib dxerr.lib dxguid.lib dxgi.lib d3d11.lib)
	set(GraphicsRuntimeDx11ComponentInstallTargets ${GraphicsRuntimeDx11ComponentInstallTargets} GraphicsRuntimeDx11Component)
	set_target_properties(GraphicsRuntimeDx11Component PROPERTIES FOLDER Graphics)
elseif(THOR_BUILD_STATIC)
	add_library(LibGraphicsRuntimeDx11Component STATIC ${GraphicsRuntimeDx11Component_Src})
	target_link_libraries(	LibGraphicsRuntimeDx11Component
							debug LibFramework_d
							debug LibThorMath_d
							debug d3dx11d.lib
							optimized LibFramework
							optimized LibThorMath
							optimized d3dx11.lib)
	target_link_libraries(LibGraphicsRuntimeDx11Component d3dcompiler.lib dxerr.lib dxguid.lib dxgi.lib d3d11.lib)
	set(GraphicsRuntimeDx11ComponentInstallTargets ${GraphicsRuntimeDx11ComponentInstallTargets} LibGraphicsRuntimeDx11Component)
	set_target_properties(LibGraphicsRuntimeDx11Component PROPERTIES FOLDER Graphics)
endif()

thor_install( GraphicsRuntimeDx11ComponentInstallTargets )