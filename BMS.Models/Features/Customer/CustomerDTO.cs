﻿using BMS.Models.Features.Account;

namespace BMS.Models.Features.Customer;

public class CustomerDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string CustomerNo { get; set; }
}

public class CusWithAccsDTO
{
    public CustomerDTO CusDTO { get; set; }
    public List<AccountDTO> AccsDTO { get; set; }
}
