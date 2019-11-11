using AutoMapper;
using Kanbersky.Authentication.Business.DTO.Request;
using Kanbersky.Authentication.Business.DTO.Response;
using Kanbersky.Authentication.Entities.Concrete;

namespace Kanbersky.Authentication.Business.Mappings.AutoMapper
{
    public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<User, UserAuthenticateRequest>().ReverseMap();
            CreateMap<User, UserAuthenticateResponse>().ReverseMap();
            CreateMap<User, UserListResponse>().ReverseMap();
        }
    }
}
