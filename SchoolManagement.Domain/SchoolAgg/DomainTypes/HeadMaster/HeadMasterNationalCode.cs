using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg.DomainTypes.HeadMaster
{
    public class HeadMasterNationalCode : SimpleValueObject<string>
    {
        public HeadMasterNationalCode(string value) : base(value)
        {
        }
    }
}