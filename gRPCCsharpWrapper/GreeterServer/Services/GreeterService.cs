using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greeter;

namespace GreeterServer
{
    public class GreeterService : Greeter.Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private CppServiceWrapper cppServiceWrapper;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
            cppServiceWrapper = new CppServiceWrapper();
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine("hello in c#");
            cppServiceWrapper.SayHello(request.Name);
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
