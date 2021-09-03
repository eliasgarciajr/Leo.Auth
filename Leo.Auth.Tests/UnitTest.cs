using Leo.Auth.Models;
using Leo.Auth.Repositories;
using Leo.Auth.Services;
using Xunit;

namespace Leo.Auth.Tests
{
    public class UnitTest
    {
        [Fact]
        public void AuthenticateSuccess()
        {
            //arrange
            var login = new User { Username = "elias", Password = "elias@123" };
            //act
            var result = TokenService.GenerateToken(login);
            //assert
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result.Token));
        }

        [Fact]
        public void AuthenticateError()
        {
            //arrange
            var login = new User { Username = "elias", Password = "123456465879" };
            //act
            var result = UserRepository.Get(login.Username, login.Password);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public void ValidatePasswordSuccess()
        {
            //arrange
            var model = new UserPassword { Password = "elias@123" };
            //act
            var result = PasswordService.ValidatePassword(model.Password);
            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ValidatePasswordError()
        {
            //arrange
            var model = new UserPassword { Password = "21313213" };
            //act
            var result = PasswordService.ValidatePassword(model.Password);
            //assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void GeneratePasswordSuccess()
        {
            //arrange

            //act
            var result = PasswordService.GeneratePassword();
            //assert
            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}
