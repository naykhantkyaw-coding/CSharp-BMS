using BMS.Shared;
using BMS.Shared.DapperService;

using BMS.Models.Entities.Account;
using BMS.Models.Queries;
namespace BMS.WebAPI.Features.Account;
public class DA_Account
{
    private readonly DapperService _dapper;

    public DA_Account()
    {
        _dapper = new DapperService(DBConnection.ConnectionBuilder.ConnectionString);
    }

    public int CreateAccount(AccountEntity account)
    {
        int result = _dapper.Execute<AccountEntity>(AccountQuery.InsertQuery, account);
        return result;
    }

    public List<AccountEntity> GetAllAccounts()
    {
        List<AccountEntity> accounts = _dapper.Query<AccountEntity>(AccountQuery.SelectAllQuery);
        return accounts;
    }

    public AccountEntity GetAccount(int id)
    {
        AccountEntity account = _dapper.QueryFirstOrDefault<AccountEntity>(AccountQuery.SelectQuery, new { AccountId = id });
        return account;
    }

    public int UpdateAccount(int id, AccountEntity account)
    {
        account.AccountId = id;
        int result = _dapper.Execute<AccountEntity>(AccountQuery.UpdateQuery, account);
        return result;
    }

    public int DeleteAccount(int id)
    {
        int result = _dapper.Execute<AccountEntity>(AccountQuery.DeleteQuery, new { AccountId = id });
        return result;
    }
}
