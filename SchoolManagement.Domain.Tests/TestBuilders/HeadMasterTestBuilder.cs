using System;
using Framework.Core;
using SchoolManagement.Domain.SchoolAgg;
using SchoolManagement.Domain.SchoolAgg.DomainTypes.HeadMaster;

namespace SchoolManagement.Domain.Tests.TestBuilders
{
    public class HeadMasterTestBuilder : BaseBuilder<HeadMaster>
    {
        public long Id = 132;
        public HeadMasterName Name = new HeadMasterName("reza gholami");
        public HeadMasterNationalCode NationalCode = new HeadMasterNationalCode("0016534988");
        public HeadMasterPhoneNumber PhoneNumber = new HeadMasterPhoneNumber("087965489");
        public HeadMasterEmail Email = new HeadMasterEmail("reza.gholami@outlook.com");
        public string Degree = "licence";
        public string Major = "computer science";

        public HeadMasterTestBuilder But()
        {
            return new HeadMasterTestBuilder();
        }

        public HeadMasterTestBuilder With(HeadMasterName name)
        {
            Name = name;
            return this;
        }

        public HeadMasterTestBuilder With(HeadMasterNationalCode nationalCode)
        {
            NationalCode = nationalCode;
            return this;
        }

        public HeadMasterTestBuilder With(HeadMasterPhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public HeadMasterTestBuilder With(HeadMasterEmail email)
        {
            Email = email;
            return this;
        }

        public override HeadMaster Build()
        {
            return new HeadMaster(Id, Name, NationalCode, PhoneNumber, Email, Degree, Major);
        }
    }
}