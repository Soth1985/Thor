##########################################################################
# GraphicsRuntimeSharedComponent										 #
##########################################################################
file(GLOB GraphicsRuntimeSharedComponent_CPP "*.cpp")
file(GLOB GraphicsRuntimeSharedComponent_H "*.h")

set(GraphicsRuntimeSharedComponent_Src ${GraphicsRuntimeSharedComponent_CPP} ${GraphicsRuntimeSharedComponent_H})

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_definitions(-DTHOR_MATH_IMPORT)
	add_definitions(-DTHOR_GRAPHICS_RUNTIME_SHARED_EXPORT)
	add_library(GraphicsRuntimeSharedComponent SHARED ${GraphicsRuntimeSharedComponent_Src})
	target_link_libraries(	GraphicsRuntimeSharedComponent
							debug Framework_d
							debug ThorMath_d
							optimized Framework
							optimized ThorMath)
	set(GraphicsRuntimeSharedComponentInstallTargets ${GraphicsRuntimeSharedComponentInstallTargets} GraphicsRuntimeSharedComponent)
	set_target_properties(GraphicsRuntimeSharedComponent PROPERTIES FOLDER Graphics)
elseif(THOR_BUILD_STATIC)
	add_library(LibGraphicsRuntimeSharedComponent STATIC ${GraphicsRuntimeSharedComponent_Src})
	target_link_libraries(	LibGraphicsRuntimeSharedComponent
							debug LibFramework_d
							debug LibThorMath_d
							optimized LibFramework
							optimized LibThorMath)
	set(GraphicsRuntimeSharedComponentInstallTargets ${GraphicsRuntimeSharedComponentInstallTargets} LibGraphicsRuntimeSharedComponent)
	set_target_properties(LibGraphicsRuntimeSharedComponent PROPERTIES FOLDER Graphics)
endif()

thor_install( GraphicsRuntimeSharedComponentInstallTargets )