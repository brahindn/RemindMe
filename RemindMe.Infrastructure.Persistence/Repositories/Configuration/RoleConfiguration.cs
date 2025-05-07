using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Id = "5301bb12-cf21-4d25-924d-3aacae3f4d4a"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "0936f344-48dc-42a9-b44e-9957fa530b80"
                });
        }
    }
}
