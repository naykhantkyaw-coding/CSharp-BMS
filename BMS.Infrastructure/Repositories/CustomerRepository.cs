using BMS.Common;
using BMS.Infrastructure.Entities;
using BMS.Infrastructure.Queries;


namespace BMS.Infrastructure.Repositories
{
    public class CustomerRepository
    {
        private readonly DapperService _dapper;

        public CustomerRepository()
        {
            _dapper = new DapperService(DBConnection.ConnectionBuilder.ConnectionString);
        }

        public int CreateCustomer(Customer customer)
        {
            int result = _dapper.Execute<Customer>(CustomerQuery.InsertQuery, customer);
            return result;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = _dapper.Query<Customer>(CustomerQuery.SelectAllQuery);
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = _dapper.QueryFirstOrDefault<Customer>(CustomerQuery.SelectQuery, new {CustomerId = id});
            return customer;
        }

        public int UpdateCustomer(int id, Customer customer)
        {
            customer.CustomerId = id;
            int result = _dapper.Execute<Customer>(CustomerQuery.UpdateQuery, customer);
            return result;
        }

        public int DeleteCustomer(int id)
        {
            int result = _dapper.Execute<Customer>(CustomerQuery.DeleteQuery, new { CustomerId = id });
            return result;
        }
    }
}
