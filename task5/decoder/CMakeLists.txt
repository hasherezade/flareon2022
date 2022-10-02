cmake_minimum_required (VERSION 3.0)

project ( decoder )

set(CMAKE_CXX_FLAGS_RELEASE "${CMAKE_CXX_FLAGS_RELEASE} /MT")

set (hdrs
	rc4.h
	md5.h
	base64.h
)

set (srcs
	rc4.cpp
	md5.cpp
	base64.cpp
)

add_executable ( ${PROJECT_NAME} ${hdrs} ${srcs} ${rsrc} main.cpp )


INSTALL( TARGETS ${PROJECT_NAME} DESTINATION ${CMAKE_INSTALL_PREFIX} COMPONENT ${PROJECT_NAME} )
