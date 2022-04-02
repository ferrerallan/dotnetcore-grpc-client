using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

Console.WriteLine("Initializing poc...");
var channel = GrpcChannel.ForAddress("http://localhost:5069", new GrpcChannelOptions
    {
        MaxReceiveMessageSize = 500 * 1024 * 1024, // 5 MB
        MaxSendMessageSize = 500 * 1024 * 1024 // 2 MB
    });
var client = new Greeter.GreeterClient(channel);
DateTime startTime = DateTime.Now;
    
Console.WriteLine("Requesting data...");
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });

Console.WriteLine("Requesting data... Done");

DateTime endtime = DateTime.Now;
TimeSpan duration = endtime-startTime; 
Console.WriteLine($"Duration: {duration.Seconds.ToString()} seconds");
Console.WriteLine("Press any key to show the data...");
Console.ReadLine();
Console.WriteLine(reply);

