using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KanDann.Server.Models.Seeders
{
    public class RolesSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role { Id=1,Name=RoleEnum.Admin},
                new Role { Id=2,Name=RoleEnum.User },
                new Role { Id=3, Name=RoleEnum.Seeker}
            );
        }
    }
}
