using BMS.Infrastructure.Entities;
using BMS.Infrastructure.Repositories;

namespace BMS.Application.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerService()
        {
            _customerRepo = new CustomerRepository();  
        }

        public int CreateCustomer(Customer customer)
        {
            return _customerRepo.CreateCustomer(customer);
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepo.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepo.GetCustomer(id);
        }

        public int UpdateCustomer(int id, Customer customer)
        {
            return _customerRepo.UpdateCustomer(id, customer);
        }

        public int DeleteCustomer(int id)
        {
            return _customerRepo.DeleteCustomer(id);
        }
    }
}
