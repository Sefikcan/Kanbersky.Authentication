using Kanbersky.Authentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Kanbersky.Authentication.DAL.Concrete.EntityFramework.Context
{
    public class KanberContext : DbContext
    {
        public KanberContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
