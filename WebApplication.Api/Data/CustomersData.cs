using System.Collections.Generic;
using System.Linq;
using WebApplication.Api.Models;

namespace WebApplication.Api.Data
{
    public class CustomersData
    {
        private static readonly List<Customer> Customers = new List<Customer>
        {
            new Customer{ Id = 1, Firstname = "John", Lastname = "Khan" },
            new Customer{ Id = 2, Firstname = "Saqib", Lastname = "Singh" },
            new Customer{ Id = 3, Firstname = "Naveen", Lastname = "Jonathan" }
        };

        public Customer Get(int id)
        {
            return Customers.FirstOrDefault(x => x.Id == id);
        }

        public List<Customer> Find(string name)
        {
            return Customers.Where(x => x.Firstname.ToLower().Contains(name.ToLower()) || x.Lastname.ToLower().Contains(name.ToLower())).ToList();
        }

        public int Add(Customer customer)
        {
            customer.Id = Customers.Count + 1;
            Customers.Add(customer);
            return customer.Id;
        }
    }
}