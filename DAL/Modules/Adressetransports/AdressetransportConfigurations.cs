using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Adressetransports;
public static class AdressetransportConfigurations
{
    public static EntityTypeBuilder<Adressetransport> Configure(this EntityTypeBuilder<Adressetransport> entity)
    {
        entity.ToTable("adressetransport");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Adresse)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("adresse");

        entity.Property(e => e.CodePostal)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("codePostal");

        entity.Property(e => e.Latitude)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("latitude");

        entity.Property(e => e.Longitude)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("longitude");

        entity.Property(e => e.MailContact)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("mailContact");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nom");

        entity.Property(e => e.NomContact)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nomContact");

        entity.Property(e => e.Pays)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("pays");

        entity.Property(e => e.TelContact)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("telContact");

        entity.Property(e => e.Ville)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("ville");

        return entity;
    }
}
