using System;
using FluentAssertions;
using TicketManagement.Domain.Tests.TestBuilders;
using Xunit;

namespace TicketManagement.Domain.Tests.Model
{
    public class TicketTests
    {
        [Fact]
        public void Constructor_Should_Construct_Ticket_Properly()
        {
            //Arrange
            var ticketBuilder = new TicketTestBuilder();

            //Act
            var ticket = ticketBuilder.Build();

            //Assert
            ticket.Id.DbId.Should().Be(ticketBuilder.Id.DbId);
            ticket.SchoolId.Value.Should().Be(ticketBuilder.SchoolId.Value);
            ticket.Type.Value.Should().Be(ticketBuilder.Type.Value);
            ticket.Message.Should().Be(ticketBuilder.Message);
        }


        [Fact]
        public void Constructor_Should_Throw_NullReferenceException_When_Message_Is_Null()
        {
            //Arrange
            var ticketBuilder = new TicketTestBuilder().WithMessage(null);

            //Act
            Action ticketConstruction = () => ticketBuilder.Build();

            //Assert
            ticketConstruction.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void Constructor_Should_Throw_NullReferenceException_When_Message_Is_Empty()
        {
            //Arrange
            var ticketBuilder = new TicketTestBuilder().WithMessage("");

            //Act
            Action ticketConstruction = () => ticketBuilder.Build();

            //Assert
            ticketConstruction.Should().Throw<NullReferenceException>();
        }
    }
}