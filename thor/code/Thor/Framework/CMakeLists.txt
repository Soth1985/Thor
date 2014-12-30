option(USE_PHYSFS "Whether to include support for PhysFS" ON)
option(USE_TR1FS "Whether to include support for Std.FileSystem" OFF)

if(USE_PHYSFS AND USE_TR1FS)
	message(FATAL_ERROR "You should use either PhysFS, or Std.Filesystem, but not both at once")
endif()

if(NOT USE_PHYSFS AND NOT USE_TR1FS)
	message(FATAL_ERROR "You have to select a filesystem implementation")
endif()

set(FrameworkInstallTargets "")

#set source files

file(GLOB FrameworkCore_CPP "*.cpp")
file(GLOB FrameworkCore_H "*.h")

set(FrameworkCore_Src ${FrameworkCore_CPP} ${FrameworkCore_H})

file(GLOB Filesystem_CPP "Filesystem/*.cpp")
file(GLOB Filesystem_H "Filesystem/*.h")

set(Filesystem_Src ${Filesystem_CPP} ${Filesystem_H})

file(GLOB DataModel_CPP "DataModel/*.cpp")
file(GLOB DataModel_H "DataModel/*.h")

set(DataModel_Src ${DataModel_CPP} ${DataModel_H})

file(GLOB Containers_H "Containers/*.h")

set(Containers_Src ${Containers_H})

set(Protocol_Src 
		${PROTOCOL_PATH}/ThFrameworkProtocol/ThFrameworkProtocol.dff
		${PROTOCOL_PATH}/ThFrameworkProtocol/ThFrameworkProtocol.dfp
		${PROTOCOL_PATH}/ThFrameworkProtocol/ThFrameworkProtocol.cpp
		${PROTOCOL_PATH}/ThFrameworkProtocol/ThFrameworkProtocol.h)

#configure filesystem sources

if(USE_PHYSFS)
	add_definitions(-DTHOR_USE_PHYSFS)
	thor_list_remove_file(Filesystem_Src ".*StdFileSystem.cpp")
	thor_list_remove_file(Filesystem_Src ".*StdFileSystem.h")
	thor_list_remove_file(Filesystem_Src ".*StlFileStream.cpp")
	thor_list_remove_file(Filesystem_Src ".*StlFileStream.h")
endif()

if(USE_TR1FS)
	add_definitions(-DTHOR_USE_TR1FS)
	thor_list_remove_file(Filesystem_Src ".*PhysFileStream.cpp")
	thor_list_remove_file(Filesystem_Src ".*PhysFileStream.h")
	thor_list_remove_file(Filesystem_Src ".*PhysFileSystem.cpp")
	thor_list_remove_file(Filesystem_Src ".*PhysFileSystem.h")	
endif()

#message(FATAL_ERROR "Filesystem_Src = ${Filesystem_Src}")

#configure source groups

set( Framework_Src ${FrameworkCore_Src} ${Filesystem_Src} ${Containers_Src} ${DataModel_Src} ${Protocol_Src})

source_group( Framework FILES ${FrameworkCore_Src} )
source_group( Filesystem FILES ${Filesystem_Src} )
source_group( Containers FILES ${Containers_Src} )
source_group( DataModel FILES ${DataModel_Src} )
source_group( Protocol FILES ${Protocol_Src} )

if(THOR_BUILD_SHARED)
	add_definitions(-DTHOR_FRAMEWORK_EXPORT)
	add_library(Framework SHARED ${Framework_Src})
	
	target_link_libraries(	Framework
							debug tbb_d
							optimized tbb
						 )

	if(USE_PHYSFS)
		target_link_libraries(	Framework
								debug physfs_d
								optimized physfs
							 )
	endif()

	target_link_libraries( Framework dbghelp )
	set(FrameworkInstallTargets ${FrameworkInstallTargets} Framework)
elseif(THOR_BUILD_STATIC)
	add_library(LibFramework STATIC ${Framework_Src})
	
	target_link_libraries(	LibFramework
							debug tbb_d
							optimized tbb
						 )

	if(USE_PHYSFS)
		target_link_libraries(	LibFramework
								debug libphysfs_d
								optimized libphysfs
							 )
	endif()

	target_link_libraries( LibFramework dbghelp )
	set(FrameworkInstallTargets ${FrameworkInstallTargets} LibFramework)
endif()

thor_install( FrameworkInstallTargets )