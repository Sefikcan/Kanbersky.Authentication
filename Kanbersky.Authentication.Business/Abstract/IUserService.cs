using Kanbersky.Authentication.Business.DTO.Request;
using Kanbersky.Authentication.Business.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanbersky.Authentication.Business.Abstract
{
    public interface IUserService
    {
        Task<UserAuthenticateResponse> Authenticate(UserAuthenticateRequest userAuthenticateRequest);

        Task<List<UserListResponse>> GetAll();

        Task<UserListResponse> GetById(int id);
    }
}
