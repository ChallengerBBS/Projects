namespace MyFirstAspNetCoreApp.Tests
{
    using MyFirstAspNetCoreApp.ValidationAttributes;
    using Xunit;
    public class EgnValidationAttributeTests
    {
        [Fact]
        public void Egn1234567890ShouldBeValid()
        {
            //Arrange
            var validationAttribute = new EgnValidationAttribute();

            //Act
            var result = validationAttribute.IsValid("1234567890");

            //Assert

            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("1234567899")]
        [InlineData("12345")]
        [InlineData("   ")]
        [InlineData("\0")]
        public void EgnShouldBeInvalid(string egn)
        {
            //Arrange
            var validationAttribute = new EgnValidationAttribute();

            //Act
            var result = validationAttribute.IsValid(egn);

            //Assert

            Assert.False(result);
        }
    }
}
