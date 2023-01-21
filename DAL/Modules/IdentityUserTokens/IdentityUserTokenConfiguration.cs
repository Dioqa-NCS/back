using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.IdentityUserTokens;
public static class IdentityUserTokenConfiguration
{
    public static EntityTypeBuilder<IdentityUserToken<int>> Configure(this EntityTypeBuilder<IdentityUserToken<int>> entity)
    {
        entity.Property(m => m.LoginProvider).HasMaxLength(200);
        entity.Property(m => m.Name).HasMaxLength(200);

        return entity;
    }
}
