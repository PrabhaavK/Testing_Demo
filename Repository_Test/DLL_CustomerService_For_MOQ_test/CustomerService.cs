using System.IO;
using System;

namespace DLL_CustomerService_For_MOQ_test
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public int SaveCustomer(Customer customer)
        {
            if(customer == null)
                throw new ArgumentNullException("Customer connot be null");

            if (string.IsNullOrEmpty(customer.Name))
                throw new InvalidDataException("Name cannot be empty");

            if(string.IsNullOrEmpty(customer.Email))
                throw new InvalidDataException("Email connot be empty");

            if(customer.Id == 0 && _repository.Search(customer.Email) != null)
                throw new InvalidOperationException("Customer Already exist"); 

            int custId = 0;
            if(customer.Id == 0)
            {
                custId = _repository.Add(customer);
            }
            else
            {
                custId = _repository.Update(customer);
            }

        return custId;
        }
        
    }
}
