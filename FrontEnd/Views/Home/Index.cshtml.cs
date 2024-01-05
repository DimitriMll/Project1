using FrontEnd.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Views.Home
{
    public class CustomerModel : PageModel
    {
		private MySqlController mySqlController = new MySqlController();
		private MongoController mongoController = new MongoController();
		public void OnGet()
        {

        }
        public void OnPost()
        {
            mySqlController.GetCustomersMySql();
        }
    }
}
