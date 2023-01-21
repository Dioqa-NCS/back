using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Marques;
public static class MarqueConfiguration
{
    public static EntityTypeBuilder<Marque> Configure(this EntityTypeBuilder<Marque> entity)
    {
        entity.ToTable("marque");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nom");

        return entity;
    }
}
