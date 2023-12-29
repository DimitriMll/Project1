using Consumer1.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer1.Services
{
    public class ConsumerService
    {
        public void Main(string[] args)
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
            
            var docs = Customer.GetCustomers();

            try
            {
                collection.InsertOne(docs);
                Console.WriteLine($"Successfully inserted the new document.\n {docs.first_name} {docs.last_name}, {docs.sex}, {docs.birth_date}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong trying to insert the new documents." +
                    $" Message: {e.Message}");
                Console.WriteLine(e);
                Console.WriteLine();
                return;
            }
            /*
            var allDocs = collection.Find(Builders<Customer>.Filter.Empty)
                .ToList();

            foreach (Customer customer in allDocs)
            {
                Console.WriteLine($"{customer.first_name} {customer.last_name} " +
                    $"Sex: {customer.sex}");
                Console.WriteLine();
            }                        

            var findFilter = Builders<Customer>
                .Filter.Eq(t => t.first_name,
                "John");

            var findResult = collection.Find(findFilter).FirstOrDefault();

            if (findResult == null)
            {
                Console.WriteLine(
                    "I didn't find any registers.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("We've retrieved the document:");
            Console.WriteLine(findResult.ToString());
            Console.WriteLine();
            
            var updateFilter = Builders<Customer>.Update.Set(t => t.first_name, "Caleb");            

            var options = new FindOneAndUpdateOptions<Customer, Customer>()
            {
                ReturnDocument = ReturnDocument.After
            };
            
            var updatedDocument = collection.FindOneAndUpdate(findFilter,
                updateFilter, options);

            Console.WriteLine("Here's the updated document:");
            Console.WriteLine(updatedDocument.ToString());
            Console.WriteLine();            

            var deleteResult = collection
                .DeleteMany(Builders<Customer>.Filter.Eq(r => r.first_name, "Caleb"));

            Console.WriteLine($"I deleted {deleteResult.DeletedCount} records.");

            Console.Read();*/
        }
    }
}
