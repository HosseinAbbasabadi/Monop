using Framework.Application.Command;

namespace TicketManagement.Application.Contracts.Commands
{
    public class RegisterTicket : ICommand
    {
        public long SchoolId { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
    }
}
