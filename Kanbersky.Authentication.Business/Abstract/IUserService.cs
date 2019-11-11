using Kanbersky.Authentication.Business.DTO.Request;
using Kanbersky.Authentication.Business.DTO.Response;
using Kanbersky.Authentication.Core.Utilities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanbersky.Authentication.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserAuthenticateResponse>> Authenticate(UserAuthenticateRequest userAuthenticateRequest);

        Task<IDataResult<List<UserListResponse>>> GetAll();

        Task<IDataResult<UserListResponse>> GetById(int id);
    }
}
