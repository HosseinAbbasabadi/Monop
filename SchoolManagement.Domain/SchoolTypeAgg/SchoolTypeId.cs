using Framework_Domain;

namespace SchoolManagement.Domain.SchoolTypeAgg
{
    public class SchoolTypeId : IdBase<long>
    {
        protected SchoolTypeId()
        {
        }

        public SchoolTypeId(long id) : base(id)
        {
        }
    }
}