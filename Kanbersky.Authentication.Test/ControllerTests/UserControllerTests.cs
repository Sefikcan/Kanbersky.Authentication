using Kanbersky.Authentication.Business.Abstract;
using Kanbersky.Authentication.Business.DTO.Response;
using Xunit;
using Moq;
using FluentAssertions;
using System.Collections.Generic;
using Kanbersky.Authentication.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Kanbersky.Authentication.Business.DTO.Request;

namespace Kanbersky.Authentication.Test.ControllerTests
{
    public class UserControllerTests
    {
        #region fields

        private readonly UsersController _sut;
        private readonly Mock<IUserService> _userService;
        private readonly List<UserListResponse> _userListResponse;
        private readonly UserAuthenticateResponse _userAuthenticateResponse;
        private readonly Mock<UserAuthenticateRequest> _userAuthenticateRequest;

        #endregion

        #region ctor

        public UserControllerTests()
        {
            _userService = new Mock<IUserService>();
            _userListResponse = new List<UserListResponse>();
            _userAuthenticateResponse = new UserAuthenticateResponse();
            _userAuthenticateRequest = new Mock<UserAuthenticateRequest>();
            _sut = new UsersController(_userService.Object);
        }

        #endregion

        #region methods

        [Fact]
        public void GetAll_Should_Return_As_Expected()
        {
            _userService.Setup(u => u.GetAll()).Returns(Task.FromResult(_userListResponse));

            var result = _sut.GetAll().GetAwaiter().GetResult();
            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<List<UserListResponse>>().Subject;

            Assert.Equal(_userListResponse, actual);
        }

        [Fact]
        public void Login_Should_Return_As_Expected()
        {
            _userService.Setup(u => u.Authenticate(_userAuthenticateRequest.Object)).Returns(Task.FromResult(_userAuthenticateResponse));

            var result = _sut.Login(_userAuthenticateRequest.Object).GetAwaiter().GetResult();
            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<UserAuthenticateResponse>().Subject;

            Assert.Equal(_userAuthenticateResponse, actual);
        }

        #endregion
    }
}