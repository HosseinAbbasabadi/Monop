using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg.DomainTypes
{
    public class SchoolRound : SimpleValueObject<int>
    {
        public SchoolRound(int value) : base(value)
        {
        }
    }
}