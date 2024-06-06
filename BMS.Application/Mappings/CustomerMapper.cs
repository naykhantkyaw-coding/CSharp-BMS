using BMS.Application.DTOs.Customer;
using BMS.Infrastructure.Entities;

namespace BMS.Application.Mappings;

public static class CustomerMapper
{
    public static CustomerDTO ToDTO(this Customer customer)
    {
        return new CustomerDTO
        {
            Name = customer.Name,
            Email = customer.Email,
            Address = customer.Address,
            PhoneNumber = customer.PhoneNumber,
            CustomerNo = customer.CustomerNo,
        };
    }

    public static Customer ToEntity(this CustomerDTO dto)
    {
        return new Customer
        {
            Name = dto.Name,
            Email = dto.Email,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            CustomerNo = dto.CustomerNo,
        };
    }
}
