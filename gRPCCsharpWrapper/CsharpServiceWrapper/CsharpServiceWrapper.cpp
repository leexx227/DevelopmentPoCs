#include "CsharpServiceWrapper.h"
#include <msclr\auto_gcroot.h>

using namespace msclr;
using namespace System;
using namespace Greeter;

auto_gcroot<GreeterServer::Program^> cSharpServer;

void StartServer(long long ptr)
{
	cSharpServer->Main(gcnew array<String^>{ptr.ToString()});
}
