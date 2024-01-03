using Azure.Messaging.ServiceBus;
using Consumer1.Models;
using Consumer1.Services;
using System.Text;
using Newtonsoft.Json;

// the client that owns the connection and can be used to create senders and receivers
ServiceBusClient client;

// the sender used to publish messages to the queue
ServiceBusSender sender;

MySQLConsumer mySQLConsumer = new MySQLConsumer();

var clientOptions = new ServiceBusClientOptions()
{
    TransportType = ServiceBusTransportType.AmqpWebSockets
};
client = new ServiceBusClient("Endpoint=sb://project-1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=tJ7FaBZ48ldhdLjy9QGDGYBbtonNtHyzp+ASbEAGxbc=", clientOptions);
sender = client.CreateSender("customer"); 
try
{
    var customer = mySQLConsumer.GetAllCustomers();
    foreach (var item in customer)
    {
        await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item))));
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
finally
{
    // Calling DisposeAsync on client types is required to ensure that network
    // resources and other unmanaged objects are properly cleaned up.
    await sender.DisposeAsync();
    await client.DisposeAsync();
}

Console.WriteLine("Press any key to end the application");
Console.ReadKey();