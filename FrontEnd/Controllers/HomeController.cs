using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using Consumer1.Models;
using Consumer1.Services;
using System.Net;
using MySql.Data.MySqlClient;
using Customer = Consumer1.Models.Customer;

namespace Data_Grid.Controllers
{
    public class HomeController : Controller
    {
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        MySqlConnection con = new MySqlConnection();
        List<Customer> customers = new List<Customer>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            string? connetionString = null;
            string server = "sql5.freesqldatabase.com";
            string database = "sql5673207";
            string username = "sql5673207";
            string password = "8PH51R8Euv";
            connetionString = "Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password + ";";
            _logger = logger;
            con.ConnectionString = connetionString;
        }

        public IActionResult Index()
        {
            FetchData();
            return View(customers);
        }
        private void FetchData()
        {
            if (customers.Count > 0)
            {
                customers.Clear();
            }
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}