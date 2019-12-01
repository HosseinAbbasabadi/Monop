using System;
using Framework_Domain;
using TicketManagement.Domain.TicketAgg.Constants;

namespace TicketManagement.Domain.TicketAgg
{
    public class Ticket : AggregateRootBase<TicketId>
    {
        public TicketType Type { get; }
        public SchoolId SchoolId { get; }
        public string Message { get; }

        protected Ticket()
        {
        }

        public Ticket(TicketId id, TicketType type, SchoolId schoolId, string message) : base(id)
        {
            Validate(message);

            Type = type;
            SchoolId = schoolId;
            Message = message;
        }

        private static void Validate(string message)
        {
            GuardAgainstNullOrEmptyMessage(message);
        }

        private static void GuardAgainstNullOrEmptyMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new NullReferenceException(TicketExceptionMessages.MessageIsNullOrEmpty);
        }
    }
}