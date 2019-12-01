using System;
using Framework_Domain;
using SchoolManagement.Domain.SchoolAgg.DomainTypes.HeadMaster;

namespace SchoolManagement.Domain.SchoolAgg
{
    public class HeadMaster : EntityBase<long>
    {
        public HeadMasterName Name { get; set; }
        public HeadMasterNationalCode NationalCode { get; set; }
        public HeadMasterPhoneNumber PhoneNumber { get; set; }
        public HeadMasterEmail Email { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }

        public HeadMaster(long id, HeadMasterName name, HeadMasterNationalCode nationalCode,
            HeadMasterPhoneNumber phoneNumber,
            HeadMasterEmail email,
            string degree,
            string major) : base(id)
        {
            Validate(name, nationalCode, phoneNumber, email);

            Name = name;
            NationalCode = nationalCode;
            PhoneNumber = phoneNumber;
            Email = email;
            Degree = degree;
            Major = major;
        }

        private static void Validate(HeadMasterName name, HeadMasterNationalCode nationalCode,
            HeadMasterPhoneNumber phoneNumber, HeadMasterEmail email)
        {
            GuardAgainstInvalidName(name);
            GuardAgainstInvalidNationalCode(nationalCode);
            GuardAgainstNullOrEmptyPhoneNumber(phoneNumber);
            GuardAgainsNullOrEmptyEmail(email);
        }

        private static void GuardAgainstInvalidName(HeadMasterName name)
        {
            if (string.IsNullOrEmpty(name.Value))
                throw new NullReferenceException();
        }

        private static void GuardAgainstInvalidNationalCode(HeadMasterNationalCode nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode.Value))
                throw new NullReferenceException();
        }

        private static void GuardAgainstNullOrEmptyPhoneNumber(HeadMasterPhoneNumber phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber.Value))
                throw new NullReferenceException();
        }

        private static void GuardAgainsNullOrEmptyEmail(HeadMasterEmail email)
        {
            if (string.IsNullOrEmpty(email.Value))
                throw new NullReferenceException();
        }
    }
}