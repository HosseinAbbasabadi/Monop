using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg.DomainTypes.HeadMaster
{
    public class HeadMasterName : SimpleValueObject<string>
    {
        public HeadMasterName(string name) : base(name)
        {
        }
    }
}