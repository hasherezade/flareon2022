cmake_minimum_required (VERSION 2.8)

project ( hooking_dll_tpl )

set(CMAKE_CXX_FLAGS_RELEASE "${CMAKE_CXX_FLAGS_RELEASE} /MT")

# include libdetours headers:
include_directories ( ${DETOURS_DIR}/Detours/src )

set (srcs
	main.cpp
)
set (hdrs
#put your headers here
)

add_library ( ${PROJECT_NAME} SHARED ${hdrs} ${srcs} ${rsrc})

# link with libdetours.lib
target_link_libraries ( ${PROJECT_NAME} ${DETOURS_LIB} )
add_dependencies(${PROJECT_NAME} libdetours)

INSTALL( TARGETS ${PROJECT_NAME} DESTINATION ${CMAKE_INSTALL_PREFIX} COMPONENT ${PROJECT_NAME} )
