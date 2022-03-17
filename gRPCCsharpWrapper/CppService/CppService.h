#pragma once
#include "pch.h"
#include <string>
#include <iostream>

using namespace std;

class RequestHandler
{
public:
	RequestHandler()
	{

	}

	void SayHello(string& user)
	{
		cout << "hello " << user << " in c++" << endl;
	}
};