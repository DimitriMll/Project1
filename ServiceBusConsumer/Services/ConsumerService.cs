using MongoDB.Driver;
using ServiceBusConsumer.Models;

namespace ServiceBusConsumer.Services
{
    internal class ConsumerService
    {
        private readonly MongoDBConnection mongoDBConnection;

        public ConsumerService(string mongoUri)
        {
            mongoDBConnection = new MongoDBConnection(mongoUri);
        }

        public void AddCustomerMongoDB(List<Customer> customers)
        {
            var dbName = "Cluster1DB";
            var collectionName = "customer";
            var collection = mongoDBConnection.GetCollection(dbName, collectionName);

            try
            {
                foreach (var customer in customers)
                {
                    customer.status = 2;
                    customer.updated_at = DateTime.Now;

                    var filter = Builders<Customer>.Filter.Eq(c => c.id, customer.id);
                    var updateOptions = new ReplaceOptions { IsUpsert = true };

                    collection.ReplaceOne(filter, customer, updateOptions);
                }
                Console.WriteLine($"Successfully inserted {customers.Count()} new customers in MongoDB.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong trying to insert the new documents." +
                    $" Message: {e.Message}");
                Console.WriteLine(e);
                Console.WriteLine();
                return;
            }
        }
    }
}
