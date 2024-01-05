using FrontEnd.Models;
using MySql.Data.MySqlClient;

namespace FrontEnd.Controllers
{
	public class MySqlController
	{
		List<Customer> customers = new List<Customer>();
		string? connetionString = null;
		string server = "sql5.freesqldatabase.com";
		string database = "sql5673207";
		string username = "sql5673207";
		string password = "8PH51R8Euv";
		MySqlCommand com = new MySqlCommand();
		MySqlDataReader dr;
		MySqlConnection con = new MySqlConnection();

		public List<Customer> GetCustomersMySql()
		{
			connetionString = "Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password + ";";
			con.ConnectionString = connetionString;
			try
			{
				con.Open();
				com.Connection = con;
				com.CommandText = "SELECT id,first_name,last_name,sex,birth_date,status,updated_at FROM customer";
				dr = com.ExecuteReader();
				while (dr.Read())
				{
					customers.Add(new Customer()
					{
						id = (int)dr["id"]
					,
						first_name = dr["first_name"].ToString()
					,
						last_name = dr["last_name"].ToString()
					,
						sex = dr["sex"].ToString()
					,
						birth_date = (DateTime)dr["birth_date"]
					,
						status = (int)dr["status"]
					,
						updated_at = (DateTime)dr["updated_at"]
					});
				}
				con.Close();
				return customers;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
