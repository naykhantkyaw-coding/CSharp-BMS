﻿using System.Text.RegularExpressions;

namespace BMS.Models.Features.Account;

public record AccountRequestDTO(string customerNo, EnumAccountType accountType, decimal balance, string password)
{
    public bool IsStrongPassword()
    {
        Regex hasNumber = new Regex(@"[0-9]+");
        Regex hasUpperChar = new Regex(@"[A-Z]+");
        Regex hasMiniMaxChars = new Regex(@".{8,15}");
        Regex hasLowerChar = new Regex(@"[a-z]+");
        Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

        bool IsStrong = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMiniMaxChars.IsMatch(password)
                        && hasLowerChar.IsMatch(password) && hasSymbols.IsMatch(password);

        return IsStrong;
    }

    public AccountDTO ToDTO()
    {
        return new AccountDTO
        {
            CustomerNo = customerNo,
            Balance = balance,
            Password = password,
            AccountNo = GenerateCode(accTypeString),
            AccountType = accTypeString,

        };
    }

    private string accTypeString => accountType.ToString();

    private string GenerateCode(string accType)
    {
        string prefix = accType.Trim().Substring(0, 3).ToUpper();

        Random rdn = new Random();
        string code = prefix + rdn.Next(1000, 9999).ToString();

        return code;
    }
}

public enum EnumAccountType
{
    Saving,
    Checking
}

//public class AccountRequestDTO
//{
//    public string CustomerNo { get; set; }

//    //[JsonConverter(typeof(JsonStringEnumConverter))] // to display enum as string in API
//    public EnumAccountType AccountType { get; set; }
//    public decimal Balance { get; set; }
//    public string Password { get; set; }
//}
