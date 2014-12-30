##########################################################################
# GraphicsSceneComponent												 #
##########################################################################
file(GLOB GraphicsSceneComponent_CPP "*.cpp")
file(GLOB GraphicsSceneComponent_H "*.h")

set(GraphicsSceneComponent_Src ${GraphicsSceneComponent_CPP} ${GraphicsSceneComponent_H})

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_definitions(-DTHOR_MATH_IMPORT)
	add_definitions(-DTHOR_GRAPHICS_SCENE_EXPORT)
	add_library(GraphicsSceneComponent SHARED ${GraphicsSceneComponent_Src})
	target_link_libraries(	GraphicsSceneComponent
							debug Framework_d
							debug ThorMath_d
							optimized Framework
							optimized ThorMath)
	set(GraphicsSceneComponentInstallTargets ${GraphicsSceneComponentInstallTargets} GraphicsSceneComponent)
	set_target_properties(GraphicsSceneComponent PROPERTIES FOLDER Graphics)
elseif(THOR_BUILD_STATIC)
	add_library(LibGraphicsSceneComponent STATIC ${GraphicsSceneComponent_Src})
	target_link_libraries(	LibGraphicsSceneComponent
							debug LibFramework_d
							debug LibThorMath_d
							optimized LibFramework
							optimized LibThorMath)
	set(GraphicsSceneComponentInstallTargets ${GraphicsSceneComponentInstallTargets} LibGraphicsSceneComponent)
	set_target_properties(LibGraphicsSceneComponent PROPERTIES FOLDER Graphics)
endif()

thor_install( GraphicsSceneComponentInstallTargets )