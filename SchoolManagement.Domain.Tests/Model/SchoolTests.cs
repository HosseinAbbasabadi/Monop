using System;
using FluentAssertions;
using Framework_Domain;
using SchoolManagement.Domain.SchoolAgg.DomainTypes;
using SchoolManagement.Domain.SchoolAgg.DomainTypes.School;
using SchoolManagement.Domain.Tests.TestBuilders;
using Xunit;

namespace SchoolManagement.Domain.Tests.Model
{
    public class SchoolTests
    {
        private readonly SchoolTestBuilder _aSchool;

        public SchoolTests()
        {
            _aSchool = new SchoolTestBuilder();
        }

        [Fact]
        public void Constructor_Should_Construct_School_Properly()
        {
            //Arrange
            var schoolBuilder = _aSchool;

            //Act
            var school = schoolBuilder.Build();

            //Assert
            school.Id.DbId.Should().Be(schoolBuilder.Id.DbId);
            school.Name.Should().Be(schoolBuilder.Name);
            school.Code.Should().Be(schoolBuilder.Code);
            school.Round.Should().Be(schoolBuilder.Round);
            school.Region.Should().Be(schoolBuilder.Region);
            school.Sex.Should().Be(schoolBuilder.Sex);
            school.Fields.Should().Be(schoolBuilder.Fields);
            school.Description.Should().Be(schoolBuilder.Description);
            school.AcademicYear.Should().Be(schoolBuilder.AcademicYear);
            school.SchoolType.DbId.Should().Be(schoolBuilder.SchoolType.DbId);
            school.SchoolTerm.DbId.Should().Be(schoolBuilder.SchoolTerm.DbId);
            school.Nature.Should().Be(schoolBuilder.Nature);
            school.StudentsCount.Should().Be(schoolBuilder.StudentsCount);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Should_Throw_Exception_When_Name_Is_Null_Or_Empty(string value)
        {
            //Arrange
            var name = new SchoolName(value);
            var schoolBuilder = _aSchool.But().With(name);

            //Act
            Action school = () => schoolBuilder.Build();

            //Assert
            school.Should().Throw<NullReferenceException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Should_Throw_Exception_When_Code_Is_Null_Or_Empty(string value)
        {
            //Arrange
            var code = new SchoolCode(value);
            var schoolBuilder = _aSchool.But().With(code);

            //Act
            Action school = () => schoolBuilder.Build();

            //Assert
            school.Should().Throw<NullReferenceException>();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-45)]
        public void Constructor_Should_Throw_Exception_When_Region_Is_LessThan_Or_Equal_Zero(int value)
        {
            //Arrange
            var region = new SchoolRegion(value);
            var schoolBuilder = _aSchool.But().With(region);

            //Act
            Action school = () => schoolBuilder.Build();

            //Assert
            school.Should().Throw<LessThanOrEqaulZeroValueException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-45)]
        public void Constructor_Should_Throw_Exception_When_Round_Is_LessThan_Or_Equal_Zero(int value)
        {
            //Arrange
            var round = new SchoolRound(value);
            var schoolBuilder = _aSchool.But().WithRound(round);

            //Act
            Action school = () => schoolBuilder.Build();

            //Assert
            school.Should().Throw<LessThanOrEqaulZeroValueException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-45)]
        public void Constructor_Should_Throw_Exception_When_Nature_Is_LessThan_Or_Equal_Zero(int nature)
        {
            //Arrange
            var schoolBuilder = _aSchool.But().WithNature(nature);

            //Act
            Action school = () => schoolBuilder.Build();

            //Assert
            school.Should().Throw<LessThanOrEqaulZeroValueException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-45)]
        public void Constructor_Should_Throw_Exception_When_AcademicYear_Is_LessThan_Or_Equal_Zero(int academicYear)
        {
            //Arrange
            var schoolBuilder = _aSchool.But().WithAcademicYear(academicYear);

            //Act
            Action school = () => schoolBuilder.Build();

            //Assert
            school.Should().Throw<LessThanOrEqaulZeroValueException>();
        }
    }
}