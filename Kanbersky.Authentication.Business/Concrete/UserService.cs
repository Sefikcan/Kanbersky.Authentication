using AutoMapper;
using Kanbersky.Authentication.Business.Abstract;
using Kanbersky.Authentication.Business.DTO.Request;
using Kanbersky.Authentication.Business.DTO.Response;
using Kanbersky.Authentication.Core.Helpers;
using Kanbersky.Authentication.DAL.Concrete.EntityFramework.GenericRepository;
using Kanbersky.Authentication.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kanbersky.Authentication.Business.Concrete
{
    public class UserService : IUserService
    {
        #region fields

        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public UserService(IConfiguration configuration,IGenericRepository<User> repository,IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region methods

        public async Task<UserAuthenticateResponse> Authenticate(UserAuthenticateRequest userAuthenticateRequest)
        {
            var secretKey = _configuration["AppSettings:Secret"].ToString();
            //TODO:Add Hash operations
            var user = await _repository.Get(x => x.UserName == userAuthenticateRequest.UserName && x.Password == userAuthenticateRequest.Password);

            if (user == null)
            {
                return new UserAuthenticateResponse
                {
                    Message = "User Not Found",
                    Success = false
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var response = new UserAuthenticateResponse
            {
                UserName = user.UserName,
                Token = tokenHandler.WriteToken(token)
            };

            return _mapper.Map<UserAuthenticateResponse>(response);
        }

        public async Task<List<UserListResponse>> GetAll()
        {
            var response = await _repository.GetList();
            return _mapper.Map<List<UserListResponse>>(response);
        }

        public async Task<UserListResponse> GetById(int id)
        {
            var response = await _repository.Get(x => x.Id == id);
            return _mapper.Map<UserListResponse>(response);
        }

        #endregion
    }
}
