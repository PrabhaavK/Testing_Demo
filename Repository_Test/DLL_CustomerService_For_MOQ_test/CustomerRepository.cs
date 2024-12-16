using System.Runtime.InteropServices;
using System;
using System.Linq;

namespace DLL_CustomerService_For_MOQ_test
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IList<Customer> _customerList = new List<Customer>();

        public int Add(Customer customer)
        {
            if (_customerList.Any())
            {
                customer.Id = _customerList.Max(x => x.Id) + 1;
            }
            else
            {
                customer.Id = 1;
            }
            _customerList.Add(customer);
            return customer.Id;
        }

        public int Update(Customer customer)
        {
            var cust = Get(customer.Id);

            if (cust != null)
            {
                cust.Email = customer.Email;
                cust.Name = customer.Name;
                cust.Address = customer.Address;
            }
            return customer.Id;
        }

        public void Delete(int id)
        {
            var customer = Get(id);

            if (customer != null)
            {
                _customerList.Remove(customer);
            }
        }

        public Customer? Get(int id)
        {
            return _customerList.FirstOrDefault(x => x.Id == id);
        }

        public Customer? Search(string email)
        {
            return _customerList.FirstOrDefault(x => x.Email == email);
        }

     
    }
}