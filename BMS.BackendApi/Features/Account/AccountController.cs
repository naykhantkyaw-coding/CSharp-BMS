using Microsoft.AspNetCore.Mvc;

namespace BMS.BackendApi.Features.Account;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly BL_Account _accountService;

    public AccountController()
    {
        _accountService = new BL_Account();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<AccountDTO> accounts = _accountService.GetAccounts();
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        AccountDTO account = FindAccount(id);
        if (account == null) return NotFound("no ACC found");

        return Ok(account);
    }

    [HttpPost]
    public IActionResult Create(AccountRequestDTO acc)
    {
        try
        {
            if (!acc.IsStrongPassword()) return BadRequest("pls make strong password");

            int result = _accountService.CreateAccount(acc.ToDTO());

            string msg = result > 0 ? "created success" : "failed";
            return Ok(msg);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, AccountRequestDTO acc)
    {
        try
        {
            AccountDTO isExist = FindAccount(id);
            if (isExist == null) return NotFound("no ACC found");

            AccountDTO dto = acc.ToDTO();
            if (acc.accountType.ToString() == isExist.AccountType)
            {
                dto.AccountNo = isExist.AccountNo;
            }

            int result = _accountService.UpdateAccount(id, dto);

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
        int result = _accountService.DeleteAccount(id);

        string msg = result > 0 ? "deleted success" : "failed";
        return Ok(msg);
    }

    private AccountDTO FindAccount(int id)
    {
        return _accountService.GetAccount(id);
    }
}
