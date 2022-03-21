#pragma once
class GlobalCppObject
{
public:
	GlobalCppObject()
	{
		m_counter = 0;
	}

	void IncreaseCounter()
	{
		m_counter++;
	}

	int GetCounter()
	{
		return m_counter;
	}
private:
	int m_counter;
};

