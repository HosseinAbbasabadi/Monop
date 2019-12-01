using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg.DomainTypes
{
    public class SchoolCode : SimpleValueObject<string>
    {
        public SchoolCode(string value) : base(value)
        {
        }
    }
}