using System.Diagnostics.CodeAnalysis;

namespace Kanbersky.Authentication.Business.DTO.Request
{
    [ExcludeFromCodeCoverage]
    public class UserAuthenticateRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
