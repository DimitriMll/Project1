using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace FrontEnd.Controllers
{
    public class DatabaseController
    {
        private readonly string _connectionString;
        private readonly IMongoDatabase _database;

        public DatabaseController()
        {
            string server = "mysql-database-sync-databases.a.aivencloud.com";
            string database = "defaultdb";
            string username = "avnadmin";
            string password = "AVNS_gt1fakJ31ezZm7yaQPX";
            int port = 14469;
            _connectionString = $"Server={server};Port={port};Database={database};User ID={username};Password={password};";

            var mongoUri = "mongodb+srv://admin:admin@cluster1.j4jqugk.mongodb.net/";
            var dbName = "Cluster1DB";
            var client = new MongoClient(mongoUri);
            _database = client.GetDatabase(dbName);
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>("customer");
        }
    }
}
