using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
//using var channel = GrpcChannel.ForAddress("http://localhost:5069");
var channel = GrpcChannel.ForAddress("http://localhost:5069", new GrpcChannelOptions
    {
        MaxReceiveMessageSize = 500 * 1024 * 1024, // 5 MB
        MaxSendMessageSize = 500 * 1024 * 1024 // 2 MB
    });
var client = new Greeter.GreeterClient(channel);
DateTime startTime = DateTime.Now;
    
    
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
//Console.WriteLine("Greeting: " + reply.Message);
DateTime endtime = DateTime.Now;
TimeSpan duration = endtime-startTime; 
Console.WriteLine($"Duration {duration.Seconds.ToString()}");
Console.ReadKey();

