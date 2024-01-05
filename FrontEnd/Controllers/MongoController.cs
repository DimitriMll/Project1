using FrontEnd.Models;
using MongoDB.Driver;
using MySqlX.XDevAPI;

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
    }
}
