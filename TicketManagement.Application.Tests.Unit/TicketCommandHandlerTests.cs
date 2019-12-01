using NSubstitute;
using TicketManagement.Application.Contracts.Commands;
using TicketManagement.Domain.Tests.TestBuilders;
using TicketManagement.Domain.TicketAgg;
using Xunit;

namespace TicketManagement.Application.Tests.Unit
{
    public class TicketCommandHandlerTests
    {
        [Fact]
        public void Handle_RegisterTicket_Should_Call_Create_On_Repository()
        {
            //Arrange
            var ticket = new TicketTestBuilder().Build();
            var registerTicket = ProvideSomeRegisterTicket();
            var ticketRepository = Substitute.For<ITicketRepository>();
            ticketRepository.Create(ticket);
            var ticketCommandHandler = new TicketCommandHandler(ticketRepository);

            //Act
            ticketCommandHandler.Handle(registerTicket);

            //Assert
            ticketRepository.Received(1).Create(ticket);
        }

        private static RegisterTicket ProvideSomeRegisterTicket()
        {
            return new RegisterTicket {Message = "message", SchoolId = 4, Type = 3};
        }
    }
}