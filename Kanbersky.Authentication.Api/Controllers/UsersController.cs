using Kanbersky.Authentication.Business.Abstract;
using Kanbersky.Authentication.Business.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kanbersky.Authentication.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region fields

        private readonly IUserService _userService;

        #endregion

        #region ctor

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region methods

        #region get operations

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }

        #endregion

        #region post operations


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserAuthenticateRequest request)
        {
            //User login success gibi düşünelim.

            var user = await _userService.Authenticate(request);
            return Ok(user);
        }

        #endregion

        #endregion
    }
}