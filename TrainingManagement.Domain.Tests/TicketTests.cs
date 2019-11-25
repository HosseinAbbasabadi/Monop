using System;
using Xunit;

namespace TrainingManagement.Domain.Tests
{
    public class TicketTests
    {
        [Fact]
        public void Constructor_Should_Construct_Ticket_Properly()
        {
            //Arrange
            const long id = 1;
            const string title = "some title";
            const string message = "some message";

            //Act
            var ticket = new Ticket(id, title, message);

            //Assert
            Assert.Equal(id, ticket.Id);
            Assert.Equal(title, ticket.Title);
            Assert.Equal(message, ticket.Message);
        }


        [Fact]
        public void Constructor_Should_Throw_Exception_When_Title_Is_Null()
        {
            //Arrange
            const long id = 1;
            const string title = "";
            const string message = "some message";

            //Act
            Action constructor = () => new Ticket(id, title, message);

            //Assert
            Assert.Throws<Exception>(constructor);
        }

    }
}