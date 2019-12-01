using Framework.Application.Command;
using TicketManagement.Application.Contracts.Commands;
using TicketManagement.Domain.TicketAgg;

namespace TicketManagement.Application
{
    public class TicketCommandHandler : ICommandHandler<RegisterTicket>
    {
        private const string TicketSeq = "TicketSeq";
        private readonly ITicketRepository _ticketRepository;

        public TicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void Handle(RegisterTicket command)
        {
            var id = _ticketRepository.GetNextId(TicketSeq);
            var ticketId = new TicketId(id);
            var ticketType = new TicketType(command.Type);
            var schoolId = new SchoolId(command.SchoolId);
            var ticket = new Ticket(ticketId, ticketType, schoolId, command.Message);
            _ticketRepository.Create(ticket);
        }
    }
}