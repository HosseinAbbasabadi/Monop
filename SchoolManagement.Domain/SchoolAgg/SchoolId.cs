using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg
{
    public class SchoolId : IdBase<long>
    {
        protected SchoolId()
        {
        }

        public SchoolId(long id) : base(id)
        {
        }
    }
}