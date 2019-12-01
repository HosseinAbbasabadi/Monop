using Framework.Application.Command;

namespace UserManagement.Application
{
    public class RegisterUser : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public int OrganizationId { get; set; }
        public int RoleId { get; set; }
    }   
}