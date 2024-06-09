using BMS.Mapper;

namespace BMS.BackendApi.Features.Customers;

public class BL_Customer
{
    private readonly CustomerRepository _customerRepo;

    public BL_Customer()
    {
        _customerRepo = new CustomerRepository();
    }

    public int CreateCustomer(CustomerDTO dto)
    {
        return _customerRepo.CreateCustomer(dto.Change());
    }

    public List<CustomerDTO> GetCustomers()
    {
        List<CustomerEntity> list = _customerRepo.GetCustomers();
        List<CustomerDTO> customerDTOs = list.Select(x => x.Change()).ToList();
        return customerDTOs;
    }

    public CustomerDTO GetCustomer(int id)
    {
        CustomerEntity customer = _customerRepo.GetCustomer(id);
        if (customer == null) return null;

        return customer.Change();
    }

    public int UpdateCustomer(int id, CustomerDTO customer)
    {
        return _customerRepo.UpdateCustomer(id, customer.Change());
    }

    public int DeleteCustomer(int id)
    {
        return _customerRepo.DeleteCustomer(id);
    }

    public CusWithAccsDTO GetCustomerWithAccounts(string customerNo)
    {
        CustomerWithAccounts tmp = _customerRepo.GetCustomerWithAccount(customerNo);
        if (tmp == null) return null;

        CustomerDTO cus = tmp.Customer.Change();
        List<AccountDTO> accs = tmp.Accounts.Select(x => x.Change()).ToList();

        CusWithAccsDTO cusWithAccsDTO = new CusWithAccsDTO
        {
            CusDTO = cus,
            AccsDTO = accs
        };
        return cusWithAccsDTO;
    }
}
