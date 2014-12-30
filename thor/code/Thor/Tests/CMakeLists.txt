set(TestInstallTargets "")
##########################################################################
# TestRefPtr                                                    		 #
##########################################################################
set(TestRefPtr_Src TestRefPtr.cpp)

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_executable(TestRefPtr ${TestRefPtr_Src})
	target_link_libraries(	TestRefPtr
							debug Framework_d						
							optimized Framework)
	set(TestInstallTargets ${TestInstallTargets} TestRefPtr)
	set_target_properties(TestRefPtr PROPERTIES FOLDER Tests)
elseif(THOR_BUILD_STATIC)
	add_executable(TestRefPtrStatic ${TestRefPtr_Src})
	target_link_libraries(	TestRefPtrStatic
							debug LibFramework_d							
							optimized LibFramework)
	set(TestInstallTargets ${TestInstallTargets} TestRefPtrStatic)
	set_target_properties(TestRefPtrStatic PROPERTIES FOLDER Tests)
endif()
##########################################################################
# TestFileSystem                                                   		 #
##########################################################################
set(TestFileSystem_Src TestFileSystem.cpp)

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_executable(TestFileSystem ${TestFileSystem_Src})
	target_link_libraries(	TestFileSystem
							debug Framework_d						
							optimized Framework)
	set(TestInstallTargets ${TestInstallTargets} TestFileSystem)
	set_target_properties(TestFileSystem PROPERTIES FOLDER Tests)
elseif(THOR_BUILD_STATIC)
	add_executable(TestFileSystemStatic ${TestFileSystem_Src})
	target_link_libraries(	TestFileSystemStatic
							debug LibFramework_d							
							optimized LibFramework)
	set(TestInstallTargets ${TestInstallTargets} TestFileSystemStatic)
	set_target_properties(TestFileSystemStatic PROPERTIES FOLDER Tests)
endif()
##########################################################################
# TestReflection                                                    	 #
##########################################################################
set(TestReflection_Src TestReflection.cpp)

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_executable(TestReflection ${TestReflection_Src})
	target_link_libraries(	TestReflection
							debug Framework_d
							optimized Framework)
	set(TestInstallTargets ${TestInstallTargets} TestReflection)
	set_target_properties(TestReflection PROPERTIES FOLDER Tests)
elseif(THOR_BUILD_STATIC)
	add_executable(TestReflectionStatic ${TestReflection_Src})
	target_link_libraries(	TestReflectionStatic
							debug LibFramework_d
							optimized LibFramework)
	set(TestInstallTargets ${TestInstallTargets} TestReflectionStatic)
	set_target_properties(TestReflectionStatic PROPERTIES FOLDER Tests)
endif()
##########################################################################
# TestDx11Runtime                                                      	 #
##########################################################################
set(TestDx11Runtime_Src TestDx11Runtime.cpp)

if(WIN32)
	link_directories(${DIRECTX_SDK_PATH}/lib/x86)
endif()

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_definitions(-DTHOR_GRAPHICS_RUNTIME_DX11_IMPORT)
	add_executable(TestDx11Runtime ${TestDx11Runtime_Src})
	include_directories(${DIRECTX_SDK_PATH}/include)

	target_link_libraries(	TestDx11Runtime
							debug Framework_d
							optimized Framework)
	target_link_libraries(	TestDx11Runtime
							debug GraphicsRuntimeDx11Component_d
							optimized GraphicsRuntimeDx11Component)
	set(TestInstallTargets ${TestInstallTargets} TestDx11Runtime)
	set_target_properties(TestDx11Runtime PROPERTIES FOLDER Tests)
elseif(THOR_BUILD_STATIC)
	add_executable(TestDx11RuntimeStatic ${TestDx11Runtime_Src})
	include_directories(${DIRECTX_SDK_PATH}/include)
	target_link_libraries(	TestDx11RuntimeStatic
							debug LibFramework_d
							optimized LibFramework)
	target_link_libraries(	TestDx11RuntimeStatic
							debug LibGraphicsRuntimeDx11Component_d
							optimized LibGraphicsRuntimeDx11Component)
	set(TestInstallTargets ${TestInstallTargets} TestDx11RuntimeStatic)
	set_target_properties(TestDx11RuntimeStatic PROPERTIES FOLDER Tests)
endif()
##########################################################################
# TestContainers                                                    	 #
##########################################################################
set(TestContainers_Src TestContainers.cpp)

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_executable(TestContainers ${TestContainers_Src})
	target_link_libraries(	TestContainers
							debug Framework_d
							optimized Framework)
	set(TestInstallTargets ${TestInstallTargets} TestContainers)
	set_target_properties(TestContainers PROPERTIES FOLDER Tests)
elseif(THOR_BUILD_STATIC)
	add_executable(TestContainersStatic ${TestContainers_Src})
	target_link_libraries(	TestContainersStatic
							debug LibFramework_d
							optimized LibFramework)
	set(TestInstallTargets ${TestInstallTargets} TestContainersStatic)
	set_target_properties(TestContainersStatic PROPERTIES FOLDER Tests)
endif()
##########################################################################
# TestDataModel                                                    		 #
##########################################################################
set(TestDataModel_Src TestDataModel.cpp)
set(TestDataModel_Src ${TestDataModel_Src} ${PROTOCOL_PATH}/Test/TestProtocol.cpp ${PROTOCOL_PATH}/Test/TestProtocol.h)

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_IMPORT)
	add_executable(TestDataModel ${TestDataModel_Src})
	target_link_libraries(	TestDataModel
							debug Framework_d
							optimized Framework)
	set(TestInstallTargets ${TestInstallTargets} TestDataModel)
	set_target_properties(TestDataModel PROPERTIES FOLDER Tests)
elseif(THOR_BUILD_STATIC)
	add_executable(TestDataModelStatic ${TestDataModel_Src})
	target_link_libraries(	TestDataModelStatic
							debug LibFramework_d
							optimized LibFramework)
	set(TestInstallTargets ${TestInstallTargets} TestDataModelStatic)
	set_target_properties(TestDataModelStatic PROPERTIES FOLDER Tests)
endif()
##########################################################################
thor_install( TestInstallTargets )