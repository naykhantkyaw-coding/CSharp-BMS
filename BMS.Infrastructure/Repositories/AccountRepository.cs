using BMS.Infrastructure.DB;
using BMS.Infrastructure.Entities;
using BMS.Infrastructure.Queries;

namespace BMS.Infrastructure.Repositories;

public class AccountRepository
{
    private readonly DapperService _dapper;

    public AccountRepository()
    {
        _dapper = new DapperService(DBConnection.ConnectionBuilder.ConnectionString);
    }

    public int CreateAccount(Account account)
    {
        int result = _dapper.Execute<Account>(AccountQuery.InsertQuery, account);
        return result;
    }

    public List<Account> GetAllAccounts()
    {
        List<Account> accounts = _dapper.Query<Account>(AccountQuery.SelectAllQuery);
        return accounts;
    }

    public Account GetAccount(int id)
    {
        Account account = _dapper.QueryFirstOrDefault<Account>(AccountQuery.SelectQuery, new {AccountId = id});
        return account;
    }

    public int UpdateAccount(int id, Account account)
    {
        account.AccountId = id;
        int result = _dapper.Execute<Account>(AccountQuery.UpdateQuery, account);
        return result;
    }

    public int DeleteAccount(int id)
    {
        int result = _dapper.Execute<Account>(AccountQuery.DeleteQuery, new {AccountId = id});
        return result;
    }
}
