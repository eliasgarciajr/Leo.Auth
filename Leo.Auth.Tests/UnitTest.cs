using AuthJWT.WebAPI.Models;
using AuthJWT.WebAPI.Repositories;
using AuthJWT.WebAPI.Services;
using Xunit;

namespace AuthJWT.Tests
{
    public class UnitTest
    {
        [Fact]
        public void AuthenticateSuccess()
        {
            //arrange
            var login = new User { Username = "leo", Password = "Madeiras@14072021" };
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
            var login = new User { Username = "leo", Password = "123456465879" };
            //act
            var result = UserRepository.Get(login.Username, login.Password);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public void ValidatePasswordSuccess()
        {
            //arrange
            var model = new UserPassword { Password = "Madeiras@14072021" };
            //act
            var result = PasswordService.ValidatePassword(model.Password);
            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ValidatePasswordError()
        {
            //arrange
            var model = new UserPassword { Password = "14072021" };
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
