using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg.DomainTypes.HeadMaster
{
    public class HeadMasterEmail : SimpleValueObject<string>
    {
        public HeadMasterEmail(string value) : base(value)
        {
        }
    }
}