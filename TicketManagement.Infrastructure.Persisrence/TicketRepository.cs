using Framework.Nhibernate;
using NHibernate;
using TicketManagement.Domain.TicketAgg;

namespace TicketManagement.Infrastructure.Persisrence
{
    public class TicketRepository : BaseRepository<TicketId, Ticket>, ITicketRepository
    {
        public TicketRepository(ISession session) : base(session)
        {
        }
    }
}