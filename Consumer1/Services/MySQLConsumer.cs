using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using Consumer1.Models;

namespace Consumer1.Services
{
    public class MySQLConsumer
    {
        public void getCustomersMySQL()
        {
            List<Customer> customers = new List<Customer>();
            string? connetionString = null;
            string server = "sql5.freesqldatabase.com";
            string database = "sql5673207";
            string username = "sql5673207";
            string password = "8PH51R8Euv";

            MySqlConnection cnn;
            connetionString = "Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password + ";";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                MySqlCommand com = cnn.CreateCommand();
                com.CommandText = "SELECT * FROM customer";
                MySqlDataReader reader = com.ExecuteReader();
                Console.WriteLine($"{reader.GetName(0),-4} {reader.GetName(1),-10} {reader.GetName(2),10} {reader.GetName(3),10} {reader.GetName(4),10}");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0),-4} {reader.GetString(1),-10} {reader.GetString(2),10} {reader.GetString(3),10} {reader.GetMySqlDateTime(4),10}");
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}