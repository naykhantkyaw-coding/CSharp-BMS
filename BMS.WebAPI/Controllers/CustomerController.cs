using BMS.Application.Services;
using BMS.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Customer> customers =  _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer customer = this.FindCustomer(id);
            if(customer == null) return NotFound("no customer found");

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                int result = _customerService.CreateCustomer(customer);

                string msg = result > 0 ? "created success" : "failed";
                return Ok(msg);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            try
            {
                Customer customer = this.FindCustomer(id);
                if (customer == null) return NotFound("no customer found");

                int result = _customerService.UpdateCustomer(id, customer);

                string msg = result > 0 ? "updated success" : "failed";
                return Ok(msg);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer customer = this.FindCustomer(id);
            if (customer == null) return NotFound("no customer found");

            int result = _customerService.DeleteCustomer(id);

            string msg = result > 0 ? "deleted success" : "failed";
            return Ok(msg);
        }

        private Customer FindCustomer(int id)
        {
            Customer customer = _customerService.GetCustomer(id);
            return customer;
        }
    }
}
