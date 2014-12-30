##########################################################################
# Thor Project                                                    	     #
##########################################################################
cmake_minimum_required(VERSION 3.0)

project(Thor)
set(CMAKE_DEBUG_POSTFIX _d)
set(THOR_PATH "" CACHE PATH "Path to the root directory of the engine")
set(THOR_DEPS_PATH "" CACHE PATH "Path to the directory with the engine dependencies")
set(THOR_CONTENT_PATH "" CACHE PATH "Path to the root directory of the content")
set(DIRECTX_SDK_PATH "" CACHE PATH "Path to the DirectX SDK, DirectX 11 is required")
option(THOR_BUILD_SHARED "Whether to build shared libraries" ON)
option(THOR_BUILD_STATIC "Whether to build static libraries" OFF)
option(THOR_X64 "64 bit build" ON)
option(THOR_X32 "32 bit build" OFF)

set_property(GLOBAL PROPERTY USE_FOLDERS ON)

set(CODE_PATH ${THOR_PATH}/code)
set(PROTOCOL_PATH ${CODE_PATH}/Thor/Protocol)
##########################################################################
# Version information                                                    #
##########################################################################
set(THOR_VERSION_MAJOR 0)
set(THOR_VERSION_MINOR 1)
set(THOR_VERSION_PATCH 0)
set(THOR_VERSION "${THOR_VERSION_MAJOR}.${THOR_VERSION_MINOR}.${THOR_VERSION_PATCH}")
##########################################################################
# Install                             									 #
##########################################################################
if(WIN32)
	if (THOR_X32)	
		add_definitions(-DTHOR_X32)
		if(MSVC10)
			set(THOR_RUNTIME_DIR bin/vc10_32)
			set(THOR_LIBRARY_DIR lib/vc10_32)
			set(THOR_ARCHIVE_DIR lib/vc10_32)
		endif()
	endif()
	
	if (THOR_X64)
		add_definitions(-DTHOR_X64)
		if(MSVC12)
			set(THOR_RUNTIME_DIR bin/vc12_64)
			set(THOR_LIBRARY_DIR lib/vc12_64)
			set(THOR_ARCHIVE_DIR lib/vc12_64)
		endif()
	endif()	
endif()

set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${THOR_PATH}/${THOR_RUNTIME_DIR})
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${THOR_PATH}/${THOR_ARCHIVE_DIR})
set(CMAKE_LIBRARY_OUTPUT_PATH ${THOR_PATH}/${THOR_LIBRARY_DIR})

#installs items from the TARGETS(variable name)
function(thor_install TARGETS)
	set(tgt ${${TARGETS}})
	#generate assembly info
	foreach( item ${tgt} )	
		thor_generate_assemly_info(${item} "${item}AI.inl")
	endforeach()
	install(TARGETS ${tgt}
   		RUNTIME DESTINATION ${THOR_RUNTIME_DIR}/Debug CONFIGURATIONS Debug  
    	LIBRARY DESTINATION ${THOR_LIBRARY_DIR}/Debug CONFIGURATIONS Debug
    	ARCHIVE DESTINATION ${THOR_ARCHIVE_DIR}/Debug CONFIGURATIONS Debug
	)
	
	install(TARGETS ${tgt}
   		RUNTIME DESTINATION ${THOR_RUNTIME_DIR}/Release CONFIGURATIONS Release  
    	LIBRARY DESTINATION ${THOR_LIBRARY_DIR}/Release CONFIGURATIONS Release
    	ARCHIVE DESTINATION ${THOR_ARCHIVE_DIR}/Release CONFIGURATIONS Release
	)
endfunction(thor_install) 

#removes files from the List(variable name) that match Name(string) regexp
function(thor_list_remove_file List Name)
	#message( "l = ${${List}} n = ${Name}")
	set( Result ${${List}} )
	foreach( item ${Result} )	
		#message( "i = ${item} n = ${Name}")	
		if( ${item} MATCHES ${Name} )
			#message( "matched")
			list(REMOVE_ITEM Result ${item})
			#message(FATAL_ERROR "${Result}")
		endif()
	endforeach()	
	set("${List}" ${Result} PARENT_SCOPE)
	#message(FATAL_ERROR "l = ${rr} r = ${Res}")
endfunction(thor_list_remove_file)

#generate assembly info file
function (thor_generate_assemly_info Target TemplateFile)
	set(Template ${CMAKE_CURRENT_SOURCE_DIR}/${TemplateFile}.tmpl)
	set(Generated ${CMAKE_CURRENT_SOURCE_DIR}/${TemplateFile})	

	if(EXISTS ${Template})
		#message("${Target} ${TemplateFile}  ${CMAKE_CURRENT_SOURCE_DIR} ${Found} ${Template}")
		add_custom_command(TARGET ${Target} PRE_BUILD COMMAND subwcrev ARGS ${THOR_PATH} ${Template} ${Generated} COMMENT "Run Assembly Info generator" )
	endif()
endfunction (thor_generate_assemly_info)

##########################################################################
# Additional  include and library directories                            #
##########################################################################
include_directories(${PROJECT_SOURCE_DIR})
include_directories(${THOR_PATH}/include)
include_directories(${THOR_DEPS_PATH}/include)

if(WIN32)
	link_directories( ${CMAKE_LIBRARY_OUTPUT_PATH}/Release)
	link_directories( ${CMAKE_LIBRARY_OUTPUT_PATH}/Debug)
endif()

add_definitions(-D_CRT_SECURE_NO_WARNINGS -D_SCL_SECURE_NO_WARNINGS)
add_definitions(-DTHOR_PATH="${THOR_PATH}")
add_definitions(-DTHOR_CONTENT_PATH="${THOR_CONTENT_PATH}")
add_definitions(-DBOOST_ALL_NO_LIB)
##########################################################################
# Project subdirectories												 #
##########################################################################
add_subdirectory(Thor)

