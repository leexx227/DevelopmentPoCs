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
		m_count = 0;
	}

	void SayHello(string& user)
	{
		m_count++;
		cout << "hello " << user << " in c++" << endl;
		cout << "count=" << m_count << endl;
	}

private:
	int m_count;
};