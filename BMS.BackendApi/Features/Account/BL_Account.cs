using BMS.Mapper;

namespace BMS.BackendApi.Features.Account;

public class BL_Account
{
    private readonly DA_Account _accountRepo;

    public BL_Account()
    {
        _accountRepo = new DA_Account();
    }

    public int CreateAccount(AccountDTO dto)
    {
        return _accountRepo.CreateAccount(dto.Change());
    }

    public List<AccountDTO> GetAccounts()
    {
        List<AccountEntity> accounts = _accountRepo.GetAllAccounts();
        List<AccountDTO> accountDTOs = accounts.Select(x => x.Change()).ToList();
        return accountDTOs;
    }

    public AccountDTO GetAccount(int id)
    {
        AccountEntity account = _accountRepo.GetAccount(id);
        if (account == null) return null;

        return account.Change();
    }

    public int UpdateAccount(int id, AccountDTO dto)
    {
        return _accountRepo.UpdateAccount(id, dto.Change());
    }

    public int DeleteAccount(int id)
    {
        return _accountRepo.DeleteAccount(id);
    }
}
