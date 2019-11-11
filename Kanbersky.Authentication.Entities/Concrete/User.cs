using Kanbersky.Authentication.Core.Entities;
using Kanbersky.Authentication.Entities.Abstract;

namespace Kanbersky.Authentication.Entities.Concrete
{
    public class User:BaseEntity,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
