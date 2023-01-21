using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.IdentitityRoles;
public static class IdentityRoleConfiguration
{
    public static EntityTypeBuilder<IdentityRole<int>> Configure(this EntityTypeBuilder<IdentityRole<int>> entity)
    {
        entity.Property(m => m.NormalizedName).HasMaxLength(200);

        return entity;
    }
}
