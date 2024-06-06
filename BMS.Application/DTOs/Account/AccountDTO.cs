namespace BMS.DTOs.Account
{
    public class AccountDTO
    {
        public string AccountNo { get; set; }
        public string CustomerNo { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Password { get; set; }

        private void GenerateCode(string accType)
        {
            string prefix = accType.Trim().Substring(0, 4).ToUpper();

            Random rdn = new Random();
            string code = prefix + rdn.Next(1000, 9999).ToString();

            AccountNo = code;
        }
    }
}
