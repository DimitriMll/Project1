using Azure.Messaging.ServiceBus;
using Consumer1.Models;
using Consumer1.Services;
using System;
using System.Threading.Tasks;

ServiceBusClient client;
ServiceBusProcessor processor;
ConsumerService consumerService = new ConsumerService();
List<Customer> customersList = new List<Customer>();

var clientOptions = new ServiceBusClientOptions()
{
    TransportType = ServiceBusTransportType.AmqpWebSockets
};
client = new ServiceBusClient("Endpoint=sb://project-1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=tJ7FaBZ48ldhdLjy9QGDGYBbtonNtHyzp+ASbEAGxbc=", clientOptions);

processor = client.CreateProcessor("customer", new ServiceBusProcessorOptions());

try
{
    processor.ProcessMessageAsync += MessageHandler;

    processor.ProcessErrorAsync += ErrorHandler;

    await processor.StartProcessingAsync();

    Console.WriteLine("Wait for a minute and then press any key to end the processing");
    Console.ReadKey();

    Console.WriteLine("\nStopping the receiver...");
    await processor.StopProcessingAsync();
    Console.WriteLine("Stopped receiving messages");
}
finally
{
    await processor.DisposeAsync();
    await client.DisposeAsync();
}

async Task MessageHandler(ProcessMessageEventArgs args)
{
    var message = args.Message;
    var customer = message.Body.ToObjectFromJson<Customer>();
    Console.WriteLine($"Received: {customer.first_name} {customer.last_name}");
    customersList.Add(customer);
    consumerService.AddCustomerMongoDB(customersList);
    await args.CompleteMessageAsync(args.Message);
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}