using System;
using Framework_Domain;
using SchoolManagement.Domain.SchoolAgg.DomainTypes;
using SchoolManagement.Domain.SchoolAgg.DomainTypes.School;
using SchoolManagement.Domain.SchoolTermAgg;
using SchoolManagement.Domain.SchoolTypeAgg;

namespace SchoolManagement.Domain.SchoolAgg
{
    public class School : AggregateRootBase<SchoolId>
    {
        public SchoolName Name { get; }
        public SchoolCode Code { get; }
        public SchoolRegion Region { get; }
        public SchoolRound Round { get; }
        public int Sex { get; }
        public string Fields { get; }
        public int AcademicYear { get; }
        public int Nature { get; }
        public string Description { get; }
        public long StudentsCount { get; }
        public SchoolContactInfo ContactInfo { get; set; }
        public HeadMaster HeadMaster { get; }
        public SchoolTypeId SchoolType { get; }
        public SchoolTermId SchoolTerm { get; }

        public School(SchoolId id, SchoolName name, SchoolCode code, SchoolRegion region, SchoolRound round,
            SchoolContactInfo contactInfo,
            int sex, string fields, int academicYear,
            HeadMaster headMaster, SchoolTypeId schoolType, SchoolTermId schoolTerm, int nature,
            string description, long studentsCount) : base(id)
        {
            Validate(name.Value, code.Value, region.Value, round.Value, academicYear, nature);

            Name = name;
            Code = code;
            Region = region;
            Round = round;
            Sex = sex;
            Fields = fields;
            AcademicYear = academicYear;
            HeadMaster = headMaster;
            SchoolType = schoolType;
            SchoolTerm = schoolTerm;
            Nature = nature;
            Description = description;
            StudentsCount = studentsCount;
            ContactInfo = contactInfo;
        }

        private static void Validate(string name, string code, int region, int round, int academicYear, int nature)
        {
            GuardAgainsInvalidName(name);
            GuardAgainstInvalidCode(code);
            GuardAgainstInvalidRegion(region);
            GuardAgainstInvalidRound(round);
            GuardAgainstInvalidAcademicYear(academicYear);
            GuardAgainstInvalidNature(nature);
        }


        private static void GuardAgainsInvalidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new NullReferenceException();
        }

        private static void GuardAgainstInvalidCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new NullReferenceException();
        }

        private static void GuardAgainstInvalidRegion(int region)
        {
            if (region <= 0)
                throw new LessThanOrEqaulZeroValueException();
        }

        private static void GuardAgainstInvalidRound(int round)
        {
            if (round <= 0)
                throw new LessThanOrEqaulZeroValueException();
        }

        private static void GuardAgainstInvalidAcademicYear(int academicYear)
        {
            if (academicYear <= 0)
                throw new LessThanOrEqaulZeroValueException();
        }

        private static void GuardAgainstInvalidNature(int nature)
        {
            if (nature <= 0)
                throw new LessThanOrEqaulZeroValueException();
        }
    }
}