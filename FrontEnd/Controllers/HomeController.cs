using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MySqlController mySqlController = new MySqlController();
        private MongoController mongoController = new MongoController();

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		public IActionResult Index()
        {
            var viewModel = new CustomersViewModel
            {
                customersMySql = mySqlController.GetCustomersMySql(),
                customersMongo = mongoController.GetCustomersMongo()
            };

            return View(viewModel);
        }
        public async Task<IActionResult> AddCustomerAsync()
        {
            Customer customer = new Customer();
            customer.first_name = Request.Form["firstName"];
            customer.last_name = Request.Form["lastName"];
            customer.sex = Request.Form["sex"];
            customer.birth_date = DateTime.Parse(Request.Form["birthDate"]);
            customer.status = 1;
            customer.updated_at = DateTime.Now;
            await mySqlController.InsertCustomerMySql(customer);
			return RedirectToAction("Index");
		}
        public async Task<IActionResult> SyncAsync()
        {
            List<Customer>customersMySql = new List<Customer>();
            customersMySql = mySqlController.GetCustomersMySql();

            await mongoController.AddCustomerMongoDB(customersMySql);

			return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}