using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg.DomainTypes
{
    public class SchoolName : SimpleValueObject<string>
    {
        public SchoolName(string value) : base(value)
        {
        }
    }
}