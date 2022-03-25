#pragma once
#include "pch.h"
#include <string>
#include <iostream>

#include "GlobalCppObject.h"

using namespace std;

class RequestHandler
{
public:
	RequestHandler(long long ptr)
	{
		m_count = 0;
		g_GlobalCppObject = (GlobalCppObject*)ptr;
	}

	void SayHello(string& user)
	{
		m_count++;
		if (g_GlobalCppObject == NULL)
		{
			cout << "Global object is not initialized" << endl;
			return;			
		}
		g_GlobalCppObject->IncreaseCounter();
		cout << "hello " << user << " in c++" << endl;
		cout << "count=" << m_count << endl;
		cout << "global counter=" << g_GlobalCppObject->GetCounter() << endl;
	}

private:
	int m_count;
};