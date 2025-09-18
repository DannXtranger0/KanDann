using KanDann.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KanDann.Server.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserTokens> UserTokens { get; set; }
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
