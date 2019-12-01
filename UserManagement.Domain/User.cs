using System;
using Framework_Domain;

namespace UserManagement.Domain
{
    public class User : IAggregateRoot
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public int OrganizationId { get; set; }
        public string NationalCode { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }

        protected User(){}

        public User(Guid guid, int organizationId, string nationalCode, string fullname, string username,
            string password, string phoneNumber, string mobileNumber, int roleId)
        {
            Guid = guid;
            OrganizationId = organizationId;
            NationalCode = nationalCode;
            Fullname = fullname;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            RoleId = roleId;
            IsActive = true;
            CreationDate = DateTime.Now;
        }
    }
}