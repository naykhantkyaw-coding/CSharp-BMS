using BMS.Application.DTOs.Account;
using BMS.Application.Mappings;
using BMS.Infrastructure.Entities;
using BMS.Infrastructure.Repositories;

namespace BMS.Application.Services;

public class AccountService
{
    private readonly AccountRepository _accountRepo;

    public AccountService()
    {
        _accountRepo = new AccountRepository();
    }

    public int CreateAccount(AccountDTO dto)
    {
        return _accountRepo.CreateAccount(dto.ToEntity());
    }

    public List<AccountDTO> GetAccounts()
    {
        List<Account> accounts = _accountRepo.GetAllAccounts();
        List<AccountDTO> accountDTOs = accounts.Select(x => x.ToDTO()).ToList();
        return accountDTOs;
    }

    public AccountDTO GetAccount(int id)
    {
        Account account = _accountRepo.GetAccount(id);
        if (account == null) return null;

        return account.ToDTO();
    }

    public int UpdateAccount(int id, AccountDTO dto)
    {
        return _accountRepo.UpdateAccount(id, dto.ToEntity());
    }

    public int DeleteAccount(int id)
    {
        return _accountRepo.DeleteAccount(id);
    }
}
