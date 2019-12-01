using FluentAssertions;
using SchoolManagement.Domain.Tests.TestBuilders;
using Xunit;

namespace SchoolManagement.Domain.Tests.Model
{
    public class SchoolContactInfoTests
    {
        [Fact]
        public void Constructor_Should_Construct_SchoolContactInfoProperly()
        {
            //Arrange
            var schoolContactInfoBuilder = new SchoolContactInfoTestBuilder();

            //Act
            var schoolContactInfo = schoolContactInfoBuilder.Build();

            //Assert
            schoolContactInfo.PhoneNumbers.Should().BeEquivalentTo(schoolContactInfoBuilder.PhoneNumbers);
            schoolContactInfo.FaxNumber.Should().Be(schoolContactInfoBuilder.FaxNumber);
            schoolContactInfo.Email.Should().Be(schoolContactInfoBuilder.Email);
            schoolContactInfo.WebSite.Should().Be(schoolContactInfoBuilder.WebSite);
        }
    }
}