using FrontEnd.Models;
using MongoDB.Driver;

namespace FrontEnd.Controllers
{
    public class MongoController
    {
        public List<Customer> GetCustomersMongo()
        {
            var mongoUri = "mongodb+srv://admin:admin@cluster1.j4jqugk.mongodb.net/";
            IMongoClient client;
            IMongoCollection<Customer> collection;

            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
                Console.WriteLine(e);
                Console.WriteLine();
                return new List<Customer>();
            }

            var dbName = "Cluster1DB";
            var collectionName = "customer";

            collection = client.GetDatabase(dbName)
               .GetCollection<Customer>(collectionName);
            var customers = collection.Find(_ => true).ToList();
            return customers;
        }

		public async Task AddCustomerMongoDB(List<Customer> customers)
		{
			var mongoUri = "mongodb+srv://admin:admin@cluster1.j4jqugk.mongodb.net/";
			IMongoClient client;
			IMongoCollection<Customer> collection;

			try
			{
				client = new MongoClient(mongoUri);
			}
			catch (Exception e)
			{
				Console.WriteLine("There was a problem connecting to your " +
					"Atlas cluster. Check that the URI includes a valid " +
					"username and password, and that your IP address is " +
					$"in the Access List. Message: {e.Message}");
				Console.WriteLine(e);
				Console.WriteLine();
				return;
			}

			var dbName = "Cluster1DB";
			var collectionName = "customer";

			collection = client.GetDatabase(dbName)
			   .GetCollection<Customer>(collectionName);

			try
			{
				foreach (var customer in customers)
				{
					customer.status = 2;
					customer.updated_at = DateTime.Now;

					var filter = Builders<Customer>.Filter.Eq(c => c.id, customer.id);
					var updateOptions = new ReplaceOptions { IsUpsert = true }; // This will insert if the document doesn't exist

					await collection.ReplaceOneAsync(filter, customer, updateOptions);
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
