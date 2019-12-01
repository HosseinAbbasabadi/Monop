using Framework_Domain;

namespace TicketManagement.Domain.TicketAgg
{
    public interface ITicketRepository : IRepository<TicketId, Ticket>
    {
    }
}