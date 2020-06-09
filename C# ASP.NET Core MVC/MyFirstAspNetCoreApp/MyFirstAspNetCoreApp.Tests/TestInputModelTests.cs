namespace MyFirstAspNetCoreApp.Tests
{
    using MyFirstAspNetCoreApp.Controllers;
    using System;
    using System.Linq;
    using Xunit;
    public class TestInputModelTests
    {
        [Fact]
        public void YearAndEngShouldMatch()
        {
            var viewModel = new TestInputModel
            {
                DateOfBirth = new DateTime(1912, 1, 1),
                Egn="1234567890",
            };

            var errors = viewModel.Validate(null).Count();


            Assert.Equal(0, errors);

        }

        [Fact]
        public void YearAndEgnShouldReturnErrorWhenDontMatch()
        {
            var viewModel = new TestInputModel
            {
                DateOfBirth = new DateTime(1912, 1, 1),
                Egn = "1034567890",
            };

            var errors = viewModel.Validate(null).Count();


            Assert.Equal(01, errors);
        }
    }
}
