using Azure.Messaging.ServiceBus;
using Consumer1.Models;
using Consumer1.Services;
using System.Text;
using Newtonsoft.Json;


ServiceBusClient client;

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
    var customer = mySQLConsumer.GetCustomers();
    if (customer.Count > 0)
    {
        foreach (var item in customer)
        {
            await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item))));
        }
    }
    else
    {
        Console.WriteLine("No customers found");
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