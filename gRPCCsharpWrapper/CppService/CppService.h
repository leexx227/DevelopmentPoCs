#pragma once
#include "pch.h"
#include <string>
#include <iostream>

#include "GlobalCppObject.cpp"

using namespace std;

class RequestHandler
{
public:
	RequestHandler()
	{
		m_count = 0;
	}

	void SayHello(string& user)
	{
		m_count++;
		g_GlobalCppObject->IncreaseCounter();
		cout << "hello " << user << " in c++" << endl;
		cout << "count=" << m_count << endl;
		cout << "global counter=" << g_GlobalCppObject->GetCounter() << endl;
	}

private:
	int m_count;
};