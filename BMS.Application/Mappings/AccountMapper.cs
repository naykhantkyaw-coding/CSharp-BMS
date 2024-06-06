using BMS.Application.DTOs.Account;
using BMS.Infrastructure.Entities;

namespace BMS.Application.Mappings;

public static class AccountMapper
{
    public static AccountDTO ToDTO(this Account account)
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

    public static Account ToEntity(this AccountDTO dto)
    {
        return new Account
        {
            AccountNo = dto.AccountNo,
            CustomerNo = dto.CustomerNo,
            Balance = dto.Balance,
            AccountType = dto.AccountType,
            Password = dto.Password,
        };
    }
}
