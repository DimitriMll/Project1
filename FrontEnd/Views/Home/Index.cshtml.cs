using FrontEnd.Controllers;
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
    }
}