using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using Consumer1.Models;
using Consumer1.Services;

namespace Consumer1.Services
{
    public class MySQLConsumer
    {
        ConsumerService consumerService = new ConsumerService();

        public void SyncDatabases()
        {
            int count = 0;
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

                // Display column headers
                Console.WriteLine($"{reader.GetName(0),-4} {reader.GetName(1),-10} {reader.GetName(2),10} {reader.GetName(3),10} {reader.GetName(4),10}");

                while (reader.Read())
                {
                    // Read data from MySQL and create Customer objects
                    Console.WriteLine($"{reader.GetInt32(0),-4} {reader.GetString(1),-10} {reader.GetString(2),10} {reader.GetString(3),10} {reader.GetMySqlDateTime(4),10}");
                    customers.Add(new Customer
                    {
                        id = reader.GetInt32(0),
                        first_name = reader.GetString(1),
                        last_name = reader.GetString(2),
                        sex = reader.GetString(3),
                        birth_date = (DateTime)reader.GetMySqlDateTime(4)
                    });
                }

                // Process and add to MongoDB if customers were found and don't already exist
                if (customers.Count > 0)
                {
                    List<Customer> customersMongoDB = new List<Customer>();

                    foreach (Customer customer in customers)
                    {
                        Console.WriteLine($"Verifying customer {customer.first_name} {customer.last_name}\n");

                        // Check if the customer already exists in MongoDB
                        if (consumerService.GetCustomer(customer) == null)
                        {
                            customersMongoDB.Add(customer); // Add new customers to MongoDB
                            Console.WriteLine($"Customer {customer.first_name} {customer.last_name} does not exist in MongoDB\n");
                            Console.WriteLine($"Adding {customer.first_name} {customer.last_name} to MongoDB\n");
                        }
                        else
                        {
                            count++;
                            Console.WriteLine($"{customer.first_name} {customer.last_name} already exists in MongoDB\n");
                        }
                    }

                    if (customersMongoDB.Count() == 0)
                    {
                        Console.WriteLine($"{count} Customers already exists in MongoDB\n");
                        Console.WriteLine("No new customers to add to MongoDB\n");
                    }
                    else
                    {
                        Console.WriteLine($"{count} Customers does not exists in MongoDB\n");
                        // Add new customers to MongoDB
                        consumerService.AddCustomerMongoDB(customersMongoDB);
                    }
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