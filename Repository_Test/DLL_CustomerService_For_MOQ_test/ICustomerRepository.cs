// using System;

// namespace DLL_CustomerService_For_MOQ_test
// {
//     public Interface ICustomerRepository
//     {
//         int Add(Customer customer);
//         int Update(Customer customer);
//         void Delete(int id);
//         Customer? Get(int id);
//         Customer? Search(string email);
//         void SendSms();

//     }
// }


using System;

namespace DLL_CustomerService_For_MOQ_test
{
    public interface ICustomerRepository
    {
        int Add(Customer customer);
        int Update(Customer customer);
        void Delete(int id);
        Customer? Get(int id);
        Customer? Search(string email);
       // void SendSms();
    }
}