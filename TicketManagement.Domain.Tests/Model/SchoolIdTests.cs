using System;
using FluentAssertions;
using Framework_Domain;
using TicketManagement.Domain.TicketAgg;
using Xunit;

namespace TicketManagement.Domain.Tests.Model
{
    public class SchoolIdTests
    {
        private long _value = 45;

        [Fact]
        public void Constructor_Should_Construct_SchoolId_Properly()
        {
            //Act
            var schoolId = new SchoolId(_value);

            //Assert
            schoolId.Value.Should().Be(_value);
        }
        
        [Fact]
        public void Constructor_Should_Throw_LessThanOrEqaulZeroValueException_When_Value_Is_Zero()
        {
            //Arrange
            _value = 0;

            //Act
            Action schoolId = () => new SchoolId(_value);

            //Assert
            schoolId.Should().Throw<LessThanOrEqaulZeroValueException>();
        }

        [Fact]
        public void Constructor_Should_Throw_LessThanOrEqaulZeroValueException_When_Value_Is_Less_Than_Zero()
        {
            //Arrange
            _value = -10;

            //Act
            Action schoolId = () => new SchoolId(_value);

            //Assert
            schoolId.Should().Throw<LessThanOrEqaulZeroValueException>();
        }
    }
}