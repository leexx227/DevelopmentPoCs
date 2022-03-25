// CppMain.cpp : This file contains the 'main' function. Program execution begins and ends there.


#include <iostream>
#include "../CppService/GlobalCppObject.h"
#include "../CsharpServiceWrapper/CsharpServiceWrapper.h"

int main()
{
	if (g_GlobalCppObject == NULL)
	{
		g_GlobalCppObject = new GlobalCppObject();
	}

	g_GlobalCppObject->IncreaseCounter();
    
	StartServer((long long)g_GlobalCppObject);
}
