using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Rolecomptes;
public static class RolecompteConfiguration
{
    public static EntityTypeBuilder<Rolecompte> Configure(this EntityTypeBuilder<Rolecompte> entity)
    {
        entity.ToTable("rolecompte");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nom");

        return entity;
    }
}
