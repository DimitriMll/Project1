using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer1.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? sex { get; set; }
        public DateTime birth_date { get; set; }
         
        public static Customer GetCustomers()
        {
            return new Customer()
            {
                id = 1,
                first_name = "Joe",
                last_name = "Doe",
                sex = "Male",
                birth_date = new DateTime(1980, 2, 2)
            };
        }
    }
}
