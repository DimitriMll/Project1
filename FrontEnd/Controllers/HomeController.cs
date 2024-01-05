using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

		[HttpPost]
		public IActionResult GetCustomersMySql()
		{
			var viewModel = new CustomersViewModel
			{
				customersMySql = mySqlController.GetCustomersMySql(), // Retrieve updated data here
				customersMongo = mongoController.GetCustomersMongo()  // Other necessary data assignment
			};

			return View(viewModel); // Return the updated data to the Index view
		}
		public IActionResult Privacy()
        {
            return View();
        }        
        public ActionResult SyncAction()
        {
            Console.WriteLine("SyncAction");
            return Json(new { success = true }); // Return JSON or any necessary response
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}