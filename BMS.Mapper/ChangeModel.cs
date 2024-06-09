namespace BMS.Mapper;
public static class ChangeModel
{
    public static AccountDTO Change(this AccountEntity account)
    {
        return new AccountDTO
        {
            AccountNo = account.AccountNo,
            CustomerNo = account.CustomerNo,
            Balance = account.Balance,
            AccountType = account.AccountType,
            Password = account.Password,
        };
    }

    public static AccountEntity Change(this AccountDTO dto)
    {
        return new AccountEntity
        {
            AccountNo = dto.AccountNo,
            CustomerNo = dto.CustomerNo,
            Balance = dto.Balance,
            AccountType = dto.AccountType,
            Password = dto.Password,
        };
    }

    public static CustomerDTO Change(this CustomerEntity customer)
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

    public static CustomerEntity Change(this CustomerDTO dto)
    {
        return new CustomerEntity
        {
            Name = dto.Name,
            Email = dto.Email,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            CustomerNo = dto.CustomerNo,
        };
    }
}
