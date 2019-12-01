using System;
using System.Net.Mime;
using Framework.Core;
using TicketManagement.Domain.TicketAgg;

namespace TicketManagement.Domain.Tests.TestBuilders
{
    public class TicketTestBuilder : BaseBuilder<Ticket>
    {
        public TicketId Id = new TicketId(1);
        public string Message = "some text";
        public SchoolId SchoolId = new SchoolId(54);
        public TicketType Type = new TicketType(1);

        public static TicketTestBuilder ATicket()
        {
            return new TicketTestBuilder();
        }

        public TicketTestBuilder WithMessage(string message)
        {
            Message = message;
            return this;
        }

        public override Ticket Build()
        {
            return new Ticket(Id, Type, SchoolId, Message);
        }
    }
}