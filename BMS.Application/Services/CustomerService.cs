using BMS.Application.DTOs.Customer;
using BMS.Application.Mappings;
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

        public int CreateCustomer(CustomerDTO dto)
        {
            return _customerRepo.CreateCustomer(dto.ToEntity());
        }

        public List<CustomerDTO> GetCustomers()
        {
            List<Customer> list = _customerRepo.GetCustomers();
            List<CustomerDTO> customerDTOs = list.Select(x => x.ToDTO()).ToList();
            return customerDTOs;
        }

        public CustomerDTO GetCustomer(int id)
        {
            Customer customer = _customerRepo.GetCustomer(id);
            return customer.ToDTO();
        }

        public int UpdateCustomer(int id, CustomerDTO customer)
        {
            return _customerRepo.UpdateCustomer(id, customer.ToEntity());
        }

        public int DeleteCustomer(int id)
        {
            return _customerRepo.DeleteCustomer(id);
        }
    }
}
