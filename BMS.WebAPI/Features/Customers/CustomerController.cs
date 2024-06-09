﻿using BMS.Application.DTOs.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WebAPI.Features.Customers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly BL_Customer _customerService;

    public CustomerController()
    {
        _customerService = new BL_Customer();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<CustomerDTO> customers = _customerService.GetCustomers();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        CustomerDTO customer = FindCustomer(id);
        if (customer == null) return NotFound("no customer found");

        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Create(CustomerRequestDTO customer)
    {
        try
        {
            int result = _customerService.CreateCustomer(customer.ToDTO());

            string msg = result > 0 ? "created success" : "failed";
            return Ok(msg);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CustomerRequestDTO customer)
    {
        try
        {
            CustomerDTO cus = FindCustomer(id);
            if (cus == null) return NotFound("no customer found");

            CustomerDTO dto = customer.ToDTO();
            dto.CustomerNo = cus.CustomerNo;

            int result = _customerService.UpdateCustomer(id, dto);

            string msg = result > 0 ? "updated success" : "failed";
            return Ok(msg);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CustomerDTO customer = FindCustomer(id);
        if (customer == null) return NotFound("no customer found");

        int result = _customerService.DeleteCustomer(id);

        string msg = result > 0 ? "deleted success" : "failed";
        return Ok(msg);
    }

    [HttpGet("WithAccs/{customerNo}")]
    public IActionResult GetWithAccs(string customerNo)
    {
        CusWithAccsDTO customerWithAccs = _customerService.GetCustomerWithAccounts(customerNo);
        if (customerWithAccs == null) return NotFound("no customer found");

        return Ok(customerWithAccs);
    }

    private CustomerDTO FindCustomer(int id)
    {
        CustomerDTO customer = _customerService.GetCustomer(id);
        return customer;
    }
}
