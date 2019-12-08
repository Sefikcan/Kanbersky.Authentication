using System.Diagnostics.CodeAnalysis;

namespace Kanbersky.Authentication.Business.DTO.Response
{
    [ExcludeFromCodeCoverage]
    public class UserAuthenticateResponse:BaseResponseModel
    {
        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
