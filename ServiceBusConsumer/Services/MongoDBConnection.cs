using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using ServiceBusConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusConsumer.Services
{
    internal class MongoDBConnection
    {
        private readonly string connectionString;

        public MongoDBConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IMongoCollection<Customer> GetCollection(string dbName, string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(dbName);
            return database.GetCollection<Customer>(collectionName);
        }
    }
}
