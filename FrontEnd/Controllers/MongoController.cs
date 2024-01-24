using FrontEnd.Models;
using MongoDB.Driver;

namespace FrontEnd.Controllers
{
    public class MongoController
    {
        public List<Customer> GetCustomersMongo()
        {
            try
            {
                var databaseController = new DatabaseController();
                var collection = databaseController.GetCollection<Customer>();

                var customers = collection.Find(_ => true).ToList();
                return customers;
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
        }

		public async Task AddCustomerMongoDB(List<Customer> customers)
		{
            try
            {
                var databaseController = new DatabaseController();
                var collection = databaseController.GetCollection<Customer>();

                foreach (var customer in customers)
                {
                    customer.status = 2;
                    customer.updated_at = DateTime.Now;

                    var filter = Builders<Customer>.Filter.Eq(c => c.id, customer.id);
                    var updateOptions = new ReplaceOptions { IsUpsert = true };

                    await collection.ReplaceOneAsync(filter, customer, updateOptions);
                }

                Console.WriteLine($"Successfully inserted {customers.Count()} new customers in MongoDB.");
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
		}
	}
}