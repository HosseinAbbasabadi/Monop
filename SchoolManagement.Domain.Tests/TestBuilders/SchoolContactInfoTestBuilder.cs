using System;
using System.Collections.Generic;
using Framework.Core;
using SchoolManagement.Domain.SchoolAgg;

namespace SchoolManagement.Domain.Tests.TestBuilders
{
    public class SchoolContactInfoTestBuilder : BaseBuilder<SchoolContactInfo>
    {
        public List<string> PhoneNumbers = new List<string>();
        public string FaxNumber = "fax";
        public string WebSite = "website";
        public string Email = "email";

        public override SchoolContactInfo Build()
        {
            return new SchoolContactInfo(PhoneNumbers, FaxNumber, WebSite, Email);
        }
    }
}