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
    }
}