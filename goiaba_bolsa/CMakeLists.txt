cmake_minimum_required(VERSION 3.12)
project(goiaba_bolsa)

add_executable(goiaba_bolsa 
	 ordermatch.cpp
	 "Application.h" 
	 "Application.cpp"
)

target_include_directories(goiaba_bolsa PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/quickfix/include)
target_link_libraries(goiaba_bolsa PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/quickfix/lib/quickfix.lib)