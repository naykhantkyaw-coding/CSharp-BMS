namespace BMS.Application.DTOs.Customer
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerNo { get; set; }

        //public CustomerDTO(CustomerRequestDTO request)
        //{
        //    Name = request.Name;
        //    Email = request.Email;
        //    Address = request.Address;
        //    PhoneNumber = request.PhoneNumber;
        //    GenerateCode(request.Name);
        //}


        //private void GenerateCode(string name)
        //{
        //    string prefix = name.Trim().Substring(0, 3).ToUpper();

        //    Random rdn = new Random();
        //    string code = prefix + rdn.Next(1000, 9999).ToString();

        //    CustomerNo = code;
        //}
    }
}
