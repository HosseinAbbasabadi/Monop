using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg.DomainTypes.School
{
    public class SchoolRegion : SimpleValueObject<int>
    {
        public SchoolRegion(int value) : base(value)
        {
        }
    }
}