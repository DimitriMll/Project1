namespace FrontEnd.Models
{
	public class CustomersViewModel : Customer
	{
		public List<Customer> customersMySql { get; set; }
		public List<Customer> customersMongo { get; set; }
		public CustomersViewModel()
		{
			customersMySql = new List<Customer>();
			customersMongo = new List<Customer>();
		}
	}
}