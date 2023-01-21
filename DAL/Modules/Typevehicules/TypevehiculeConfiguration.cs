using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Typevehicules;
public static class TypevehiculeConfiguration
{
    public static EntityTypeBuilder<Typevehicule> Configure(this EntityTypeBuilder<Typevehicule> entity)
    {
        entity.ToTable("typevehicule");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Coefficiant).HasColumnName("coefficiant");

        entity.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("description");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(1)
            .HasColumnName("nom")
            .IsFixedLength(true);

        return entity;
    }
}
