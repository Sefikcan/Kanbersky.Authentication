﻿using System.Diagnostics.CodeAnalysis;

namespace Kanbersky.Authentication.Business.DTO.Response
{
    [ExcludeFromCodeCoverage]
    public class UserListResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
