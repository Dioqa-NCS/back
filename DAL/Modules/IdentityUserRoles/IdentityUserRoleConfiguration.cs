using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.IdentityUserRoles;
public static class IdentityUserRoleConfiguration
{
    public static EntityTypeBuilder<IdentityUserRole<int>> Configure(this EntityTypeBuilder<IdentityUserRole<int>> entity)
    {
        entity.Property(m => m.RoleId).HasMaxLength(200);

        return entity;
    }
}
