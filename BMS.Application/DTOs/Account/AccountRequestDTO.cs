using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BMS.DTOs.Account
{
    public class AccountRequestDTO
    {
        public string CustomerNo { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))] // to display enum as string in API
        public EnumAccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Password { get; set; }

        public enum EnumAccountType
        {
            Saving,
            Checking
        }

        public bool IsStrongPassword(string password)
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
    }
}
