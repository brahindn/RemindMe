using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RemindMe.Infrastructure.Persistence.Repositories.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "5301bb12-cf21-4d25-924d-3aacae3f4d4a",
                    ConcurrencyStamp = "5a32cbdc-da7a-ebfa-deaf-53df4ee326e0"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "0936f344-48dc-42a9-b44e-9957fa530b80",
                    ConcurrencyStamp = "f6ea9ea8-3c3d-6f7f-c2d6-cba77fa5393d"
                });
        }
    }
}
