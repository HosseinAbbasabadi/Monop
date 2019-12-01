using System.Collections.Generic;
using Framework.Core;
using SchoolManagement.Domain.SchoolAgg;
using SchoolManagement.Domain.SchoolAgg.DomainTypes;
using SchoolManagement.Domain.SchoolAgg.DomainTypes.School;
using SchoolManagement.Domain.SchoolTermAgg;
using SchoolManagement.Domain.SchoolTypeAgg;

namespace SchoolManagement.Domain.Tests.TestBuilders
{
    public class SchoolTestBuilder : BaseBuilder<School>
    {
        public SchoolId Id = new SchoolId(5);
        public SchoolName Name = new SchoolName("name");
        public SchoolCode Code = new SchoolCode("4454");
        public SchoolRegion Region = new SchoolRegion(68);
        public SchoolRound Round = new SchoolRound(56);
        public string FaxNumber = "5644853";

        public List<string> PhoneNumbers = new List<string>()
        {
            "65054354"
        };

        public string WebSite = "site.com";
        public string Email = "info@site.com";
        public int Sex = 1;
        public string Fields = "fields";
        public int AcademicYear = 2;
        public SchoolContactInfo ContactInfo = new SchoolContactInfoTestBuilder().Build();
        public HeadMaster HeadMaster = new HeadMasterTestBuilder().Build();
        public SchoolTypeId SchoolType = new SchoolTypeId(1);
        public SchoolTermId SchoolTerm = new SchoolTermId(2);
        public int Nature = 5;
        public string Description = "description";
        public long StudentsCount = 403;


        public SchoolTestBuilder But()
        {
            return new SchoolTestBuilder();
        }

        public SchoolTestBuilder With(SchoolName name)
        {
            Name = name;
            return this;
        }

        public SchoolTestBuilder With(SchoolCode code)
        {
            Code = code;
            return this;
        }

        public SchoolTestBuilder With(SchoolRegion region)
        {
            Region = region;
            return this;
        }

        public SchoolTestBuilder WithRound(SchoolRound round)
        {
            Round = round;
            return this;
        }

        public SchoolTestBuilder WithNature(int nature)
        {
            Nature = nature;
            return this;
        }

        public SchoolTestBuilder WithAcademicYear(int academicYear)
        {
            this.AcademicYear = academicYear;
            return this;
        }

        public override School Build()
        {
            return new School(Id, Name, Code, Region, Round, ContactInfo, Sex, Fields, AcademicYear, HeadMaster,
                SchoolType, SchoolTerm, Nature, Description, StudentsCount);
        }
    }
}