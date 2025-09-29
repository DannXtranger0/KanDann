using KanDann.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KanDann.Server.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserBoard> UserBoards { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<ColumnBoard> Columns { get; set; }
        public DbSet<ColumnType> ColumnTypes { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
