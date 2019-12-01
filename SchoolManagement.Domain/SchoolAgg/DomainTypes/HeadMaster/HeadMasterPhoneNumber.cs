using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg.DomainTypes.HeadMaster
{
    public class HeadMasterPhoneNumber : SimpleValueObject<string>
    {
        public HeadMasterPhoneNumber(string value) : base(value)
        {
        }
    }
}