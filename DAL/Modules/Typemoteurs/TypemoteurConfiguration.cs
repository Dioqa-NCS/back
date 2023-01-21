using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Typemoteurs;
public static class TypemoteurConfiguration
{
    public static EntityTypeBuilder<Typemoteur> Configure(this EntityTypeBuilder<Typemoteur> entity)
    {
        entity.ToTable("typemoteur");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nom");

        return entity;
    }
}
