
# .NET Core gRPC Client Example

## Description

This repository provides an example of a gRPC client application built with .NET Core. It demonstrates how to set up and use .NET Core to create a gRPC client for communication with a gRPC server, which is useful for developers looking to implement efficient, high-performance inter-service communication.

## Requirements

- .NET Core SDK
- Visual Studio or any preferred IDE

## Mode of Use

1. Clone the repository:
   ```bash
   git clone https://github.com/ferrerallan/dotnetcore-grpc-client.git
   ```
2. Navigate to the project directory:
   ```bash
   cd dotnetcore-grpc-client
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

## Implementation Details

- **Protos/**: Contains the .proto files defining the gRPC services and messages.
- **Services/**: Contains the service implementations for the gRPC client.
- **Program.cs**: The main entry point of the gRPC client application.
- **appsettings.json**: Configuration file for application settings.

### Example of Use

Here is an example of how to create a gRPC client in .NET Core:

```csharp
using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Greet;

namespace GrpcClientExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "World" });
            Console.WriteLine("Greeting: " + reply.Message);
        }
    }
}
```

This code initializes a gRPC client, connects to a gRPC server at the specified address, and sends a "Hello World" message.

## License

This project is licensed under the MIT License.

You can access the repository [here](https://github.com/ferrerallan/dotnetcore-grpc-client).
