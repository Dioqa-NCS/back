using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Typeentreprises;
public static class TypeentrepriseConfiguration
{

    public static EntityTypeBuilder<Typeentreprise> Configure(this EntityTypeBuilder<Typeentreprise> entity)
    {
        entity.ToTable("typeentreprise");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nom");

        return entity;
    }
}
