#pragma once
#include <iostream>
#include <string>
#include <msclr\marshal_cppstd.h>
#include <msclr\marshal_windows.h>
#include "../CppService/CppService.h"

using namespace std;
using namespace msclr::interop;
using namespace System;
public ref class CppServiceWrapper
{
public:
	CppServiceWrapper()
	{
		this->handler = new RequestHandler();
	}

	void SayHello(String^ user)
	{
		this->handler->SayHello(marshal_as<string>(user));
	}

private:
	RequestHandler* handler;
};

