file(GLOB GraphicsWorkbench_CPP "*.cpp")
file(GLOB GraphicsWorkbench_H "*.h")

set(GraphicsWorkbench_Src ${GraphicsWorkbench_CPP} ${GraphicsWorkbench_H})

# Tell CMake to run moc when necessary:
set(CMAKE_AUTOMOC ON)
# As moc files are generated in the binary dir, tell CMake
# to always look for includes there:
 set(CMAKE_INCLUDE_CURRENT_DIR ON)

find_package(Qt5Widgets REQUIRED)
find_package(Qt5Declarative REQUIRED)

add_definitions(-DTHOR_FRAMEWORK_IMPORT)
add_executable(GraphicsWorkbench WIN32 ${GraphicsWorkbench_Src})
target_link_libraries(	GraphicsWorkbench
						debug Framework_d glew32_d		
						optimized Framework glew32)
target_link_libraries(GraphicsWorkbench opengl32 glu32)
qt5_use_modules(GraphicsWorkbench Core Quick Gui QuickWidgets OpenGL)
set(GraphicsWorkbenchInstallTargets ${GraphicsWorkbenchInstallTargets} GraphicsWorkbench)
set_target_properties(GraphicsWorkbench PROPERTIES FOLDER Graphics)

thor_install( GraphicsWorkbenchInstallTargets )