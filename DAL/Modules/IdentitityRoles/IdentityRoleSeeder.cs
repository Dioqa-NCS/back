using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.IdentitityRoles;
public static class IdentityRoleSeeder
{
    public static EntityTypeBuilder<IdentityRole<int>> Seed(this EntityTypeBuilder<IdentityRole<int>> entity)
    {
        entity.HasData(
             new IdentityRole<int> { Id = 1, Name = "Administrateur", NormalizedName = "ADMINISTRATEUR" },
             new IdentityRole<int> { Id = 2, Name = "Client", NormalizedName = "CLIENT" }
        );

        return entity;
    }
}
