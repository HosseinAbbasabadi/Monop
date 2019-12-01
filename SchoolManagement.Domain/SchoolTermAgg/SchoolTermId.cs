using Framework_Domain;

namespace SchoolManagement.Domain.SchoolTermAgg
{
    public class SchoolTermId : IdBase<long>
    {
        protected SchoolTermId()
        {
        }

        public SchoolTermId(long id) : base(id)
        {
        }
    }
}