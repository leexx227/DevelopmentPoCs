#include "CsharpServiceWrapper.h"
#include <msclr\auto_gcroot.h>

using namespace msclr;
using namespace System;
using namespace Greeter;

auto_gcroot<GreeterServer::Program^> cSharpServer;

void StartServer()
{
	cSharpServer->Main(gcnew array<String^>{ });
}
