using System.Diagnostics.CodeAnalysis;

namespace Kanbersky.Authentication.Business.DTO.Response
{
    [ExcludeFromCodeCoverage]
    public class BaseResponseModel
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
