using MySql.Data.MySqlClient;
using ServiceBusProducer.Models;

namespace ServiceBusProducer.Services
{
    internal class ProducerService
    {
        private readonly DatabaseConnection databaseConnection;

        public ProducerService(string connectionString)
        {
            databaseConnection = new DatabaseConnection(connectionString);
        }

        public List<Customer> GetCustomersMySql()
        {
            List<Customer> customers = new List<Customer>();
            MySqlCommand com = new MySqlCommand();
            MySqlDataReader dr;
            MySqlConnection con = databaseConnection.OpenConnection();

            try
            {
                com.Connection = con;
                com.CommandText = "SELECT id,first_name,last_name,sex,birth_date,status,updated_at FROM customer where status = 1";
                dr = databaseConnection.ExecuteReader(com);

                while (dr.Read())
                {
                    customers.Add(new Customer()
                    {
                        id = (int)dr["id"],
                        first_name = dr["first_name"].ToString(),
                        last_name = dr["last_name"].ToString(),
                        sex = dr["sex"].ToString(),
                        birth_date = (DateTime)dr["birth_date"],
                        status = (int)dr["status"],
                        updated_at = (DateTime)dr["updated_at"]
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                databaseConnection.CloseConnection(con);
            }

            return customers;
        }
    }
}
