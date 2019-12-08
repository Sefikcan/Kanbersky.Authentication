using AutoMapper;
using FluentAssertions;
using Kanbersky.Authentication.Business.Concrete;
using Kanbersky.Authentication.Business.DTO.Request;
using Kanbersky.Authentication.Business.DTO.Response;
using Kanbersky.Authentication.DAL.Concrete.EntityFramework.GenericRepository;
using Kanbersky.Authentication.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Kanbersky.Authentication.Test.ServiceTests
{
    public class UserServiceTests
    {
        #region fields

        private readonly UserService sut;
        private readonly Mock<IGenericRepository<User>> _repository;
        private readonly Mock<IMapper> _mapper;
        private readonly User _user;
        private readonly UserListResponse _userResponse;
        private readonly UserAuthenticateRequest _userAuthenticateRequest;
        private readonly List<User> _users;
        private readonly List<UserListResponse> _userListResponses;
        private readonly IConfiguration _configuration;

        #endregion

        #region ctor

        public UserServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IGenericRepository<User>>();
            _userAuthenticateRequest = new UserAuthenticateRequest();
            _user = new User();
            _userResponse = new UserListResponse();
            _userListResponses = new List<UserListResponse>();
            _users = new List<User>();
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            sut = new UserService(_configuration,_repository.Object, _mapper.Object);
        }

        #endregion

        #region methods

        [Fact]
        public void GetAll_Should_Return_As_Expected()
        {
            _repository.Setup(c => c.GetList(null)).Returns(Task.FromResult(_users));
            _mapper.Setup(c => c.Map(_users,_userListResponses)).Returns(_userListResponses);

            Action action = () =>
            {
                var result = sut.GetAll().GetAwaiter().GetResult();
            };
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void GetById_Should_Return_As_Expected()
        {
            _repository.Setup(c => c.Get(It.IsAny<Expression<Func<User,bool>>>())).Returns(Task.FromResult(_user));
            _mapper.Setup(c => c.Map(_user, _userResponse)).Returns(_userResponse);

            Action action = () =>
            {
                var result = sut.GetById(It.IsAny<int>()).GetAwaiter().GetResult();
            };
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Login_Should_Return_As_Expected()
        {
            _repository.Setup(c => c.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(Task.FromResult(_user));
            _mapper.Setup(c => c.Map(_user, _userResponse)).Returns(_userResponse);
            
            Action action = () =>
            {
                var result = sut.Authenticate(_userAuthenticateRequest).GetAwaiter().GetResult();
            };
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void User_Not_Found_Return_As_Expected()
        {
            UserAuthenticateRequest userRequest = new UserAuthenticateRequest
            {
                Password = "1111",
                UserName = "test"
            };

            _repository.Setup(c => c.Get(x=>x.UserName == userRequest.UserName && x.Password == userRequest.Password)).Returns(Task.FromResult(_user));
            _mapper.Setup(c => c.Map(_user, _userResponse)).Returns(_userResponse);

            Action action = () =>
            {
                var result = sut.Authenticate(_userAuthenticateRequest).GetAwaiter().GetResult();
            };
            action.Should().NotThrow<Exception>();
        }

        #endregion
    }
}
