using Framework.Core;
using System;
using TrainingManagement.Domain;

namespace TrainingMangement.Domain.Tests.TestBuilders
{
    public class TicketTestBuilder :BaseBuilder<Ticket>
    {
        public long Id = 1;
        public string Text = "some text";
        public long SchoolId = 3432;
        public TicketType Type = new TicketType(1);



        public override Ticket Build()
        {
            throw new NotImplementedException();
        }
    }
}
