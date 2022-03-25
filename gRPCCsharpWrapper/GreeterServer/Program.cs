using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace GreeterServer
{
    using Greeter;
    class GreeterImpl : Greeter.GreeterBase
    {
        private CppServiceWrapper cppServiceWrapper;

        public GreeterImpl(long ptr)
        {
            cppServiceWrapper = new CppServiceWrapper(ptr);
        }

        // Server side handler of the SayHello RPC
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine("hello in c#");
            cppServiceWrapper.SayHello(request.Name);
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
    }

    public class Program
    {
        const int Port = 5001;

        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Greeter.BindService(new GreeterImpl(long.Parse(args[0]))) },
                Ports = { new ServerPort("127.0.0.1", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
