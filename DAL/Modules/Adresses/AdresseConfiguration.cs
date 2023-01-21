using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Adresses;
public static class AdresseConfiguration
{
    public static EntityTypeBuilder<Adresse> Configure(this EntityTypeBuilder<Adresse> entity)
    {
        entity.ToTable("adresse");

        entity.HasIndex(e => e.IdCompte, "idCompte");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Adresse1)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("adresse");

        entity.Property(e => e.CodePostal)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("codePostal");

        entity.Property(e => e.IdCompte).HasColumnName("idCompte");

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

        entity.HasOne(d => d.Compte)
            .WithMany(p => p.Adresses)
            .HasForeignKey(d => d.IdCompte)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("adresse_ibfk_1");

        return entity;
    }
}
