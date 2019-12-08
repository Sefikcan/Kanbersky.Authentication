using Kanbersky.Authentication.Core.Entities;
using Kanbersky.Authentication.Entities.Abstract;
using System.Diagnostics.CodeAnalysis;

namespace Kanbersky.Authentication.Entities.Concrete
{
    [ExcludeFromCodeCoverage]
    public class User:BaseEntity,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
