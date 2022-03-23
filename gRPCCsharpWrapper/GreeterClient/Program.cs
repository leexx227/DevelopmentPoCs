using System;
using Grpc.Core;
using System.Threading.Tasks;

namespace GreeterClient
{
    using Greeter;
    class Program
    {
        public static async Task Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:5001", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            String user = "you";

            var reply = client.SayHello(new HelloRequest { Name = user });
            Console.WriteLine("Greeting: " + reply.Message);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
