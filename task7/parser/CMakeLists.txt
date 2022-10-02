cmake_minimum_required (VERSION 3.0)

project ( task7_parser )

set(CMAKE_CXX_FLAGS_RELEASE "${CMAKE_CXX_FLAGS_RELEASE} /MT")

set (hdrs
	string_util.cpp
	rewrite_states.cpp
	clean_not_followed.cpp
	clean_rand_values.cpp
)

set (srcs
	string_util.h
	rewrite_states.h
	clean_not_followed.h
	clean_rand_values.h
)

add_executable ( ${PROJECT_NAME} ${hdrs} ${srcs} ${rsrc} main.cpp )


INSTALL( TARGETS ${PROJECT_NAME} DESTINATION ${CMAKE_INSTALL_PREFIX} COMPONENT ${PROJECT_NAME} )
