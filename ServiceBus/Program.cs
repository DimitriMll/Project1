using Azure.Messaging.ServiceBus;
using System.Text;
using Newtonsoft.Json;
using ServiceBusProducer.Services;

ServiceBusClient client;

ServiceBusSender sender;

string mySqlConnectionString = "Server=sql5.freesqldatabase.com;Database=sql5673207;Uid=sql5673207;Pwd=8PH51R8Euv;";

DatabaseConnection dbConnection = new DatabaseConnection(mySqlConnectionString);

ProducerService mySQLConsumer = new ProducerService(mySqlConnectionString);

var clientOptions = new ServiceBusClientOptions()
{
    TransportType = ServiceBusTransportType.AmqpWebSockets
};

client = new ServiceBusClient("Endpoint=sb://project-1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=tJ7FaBZ48ldhdLjy9QGDGYBbtonNtHyzp+ASbEAGxbc=", clientOptions);
sender = client.CreateSender("customer");

try
{
    var customer = mySQLConsumer.GetCustomersMySql();
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
    await sender.DisposeAsync();
    await client.DisposeAsync();
}

Console.WriteLine("Press any key to end the application");
Console.ReadKey();