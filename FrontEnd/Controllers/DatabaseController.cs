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
            string server = "sql5.freesqldatabase.com";
            string database = "sql5673207";
            string username = "sql5673207";
            string password = "8PH51R8Euv";
            _connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";

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
