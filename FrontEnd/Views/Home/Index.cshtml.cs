using FrontEnd.Controllers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Views.Home
{
    public class CustomerModel : PageModel
    {
		private MySqlController mySqlController = new MySqlController();
		private MongoController mongoController = new MongoController();
		
        public void OnPost()
        {
            mySqlController.GetCustomersMySql();
            mongoController.GetCustomersMongo();
            Response.Redirect("/");
        }

        public async Task OnAddCustomerClick()
        {
            Customer customer = new Customer();
            customer.first_name = Request.Form["firstName"];
            customer.last_name = Request.Form["lastName"];
            customer.sex = Request.Form["sex"];
            customer.birth_date = DateTime.Parse(Request.Form["birthDate"]);
            customer.status = 1;
            customer.updated_at = DateTime.Now;
            await mySqlController.InsertCustomerMySql(customer);
			Response.Redirect("/");
        }
    }
}