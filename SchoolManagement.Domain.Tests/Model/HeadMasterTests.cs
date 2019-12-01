using System;
using FluentAssertions;
using SchoolManagement.Domain.SchoolAgg.DomainTypes.HeadMaster;
using SchoolManagement.Domain.Tests.TestBuilders;
using Xunit;

namespace SchoolManagement.Domain.Tests.Model
{
    public class HeadMasterTests
    {
        private readonly HeadMasterTestBuilder _aHeadMaster;

        public HeadMasterTests()
        {
            _aHeadMaster = new HeadMasterTestBuilder();
        }

        [Fact]
        public void Constructor_Should_Construct_HeadMaster_Properly()
        {
            //Arrange
            var headMasterBuilder = _aHeadMaster;

            //Act
            var headMaster = headMasterBuilder.Build();

            //Assert
            headMaster.Id.Should().Be(headMasterBuilder.Id);
            headMaster.Name.Should().Be(headMasterBuilder.Name);
            headMaster.NationalCode.Should().Be(headMasterBuilder.NationalCode);
            headMaster.PhoneNumber.Should().Be(headMasterBuilder.PhoneNumber);
            headMaster.Email.Should().Be(headMasterBuilder.Email);
            headMaster.Degree.Should().Be(headMasterBuilder.Degree);
            headMaster.Major.Should().Be(headMasterBuilder.Major);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Should_Throw_Exception_When_Name_Is_Invalid(string value)
        {
            //Arrange
            var name = new HeadMasterName(value);
            var headMasterBuilder = _aHeadMaster.With(name);

            //Act
            Action headMaster = () => headMasterBuilder.Build();

            //Assert
            headMaster.Should().ThrowExactly<NullReferenceException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Should_Throw_Exception_When_NationalCode_Is_Invalid(string value)
        {
            //Arrange
            var nationalCode = new HeadMasterNationalCode(value);
            var headMasterBuilder = _aHeadMaster.With(nationalCode);

            //Act
            Action headMaster = () => headMasterBuilder.Build();

            //Assert
            headMaster.Should().ThrowExactly<NullReferenceException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Should_Throw_Exception_When_PhoneNumber_Is_NullOrEmpty(string value)
        {
            //Arrange
            var phoneNumber = new HeadMasterPhoneNumber(value);
            var headMasterBuilder = _aHeadMaster.But().With(phoneNumber);

            //Act
            Action headMaster = () => headMasterBuilder.Build();

            //Assert
            headMaster.Should().ThrowExactly<NullReferenceException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Should_Throw_Exception_When_Email_Is_NullOrEmpty(string value)
        {
            //Arrange
            var phoneNumber = new HeadMasterPhoneNumber(value);
            var headMasterBuilder = _aHeadMaster.But().With(phoneNumber);

            //Act
            Action headMaster = () => headMasterBuilder.Build();

            //Assert
            headMaster.Should().ThrowExactly<NullReferenceException>();
        }
    }
}