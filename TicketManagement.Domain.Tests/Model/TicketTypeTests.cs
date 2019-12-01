using System;
using FluentAssertions;
using Framework_Domain;
using TicketManagement.Domain.TicketAgg;
using Xunit;

namespace TicketManagement.Domain.Tests.Model
{
    public class TicketTypeTests
    {
        private long _value = 2;

        [Fact]
        public void _Should_Construct_TicketType_Properly()
        {
            //Arrange
            _value = 2;

            //Act
            var ticketType = new TicketType(_value);

            //Assert
            ticketType.Value.Should().Be(_value);
        }

        [Fact]
        public void Constructor_Should_Throw_LessThanOrEqaulZeroValueException_When_Value_Is_Zero()
        {
            //Arrange
            _value = 0;

            //Act
            Action schoolId = () => new TicketType(_value);

            //Assert
            schoolId.Should().Throw<LessThanOrEqaulZeroValueException>();
        }

        [Fact]
        public void Constructor_Should_Throw_LessThanOrEqaulZeroValueException_When_Value_Is_Less_Than_Zero()
        {
            //Arrange
            _value = -10;

            //Act
            Action schoolId = () => new TicketType(_value);

            //Assert
            schoolId.Should().Throw<LessThanOrEqaulZeroValueException>();
        }
    }
}