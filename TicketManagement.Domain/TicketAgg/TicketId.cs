using Framework_Domain;

namespace TicketManagement.Domain.TicketAgg
{
    public class TicketId : IdBase<long>
    {
        protected TicketId()
        {
        }

        public TicketId(long id) : base(id)
        {
        }
    }
}