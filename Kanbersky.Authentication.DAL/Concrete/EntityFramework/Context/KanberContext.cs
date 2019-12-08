using Kanbersky.Authentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Kanbersky.Authentication.DAL.Concrete.EntityFramework.Context
{
    [ExcludeFromCodeCoverage]
    public class KanberContext : DbContext
    {
        public KanberContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
