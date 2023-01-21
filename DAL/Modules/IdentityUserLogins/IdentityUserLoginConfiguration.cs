using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.IdentityUserLogins;
public static class IdentityUserLoginConfiguration
{
    public static EntityTypeBuilder<IdentityUserLogin<int>> Configure(this EntityTypeBuilder<IdentityUserLogin<int>> entity)
    {
        entity.Property(m => m.LoginProvider).HasMaxLength(200);
        entity.Property(m => m.ProviderKey).HasMaxLength(200);

        return entity;
    }
}
