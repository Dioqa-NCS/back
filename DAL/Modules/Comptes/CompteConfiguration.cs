using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Comptes;
public static class CompteConfiguration
{
    public static EntityTypeBuilder<Compte> Configure(this EntityTypeBuilder<Compte> entity)
    {
        entity.ToTable("compte");


        entity.Property(m => m.NormalizedUserName).HasMaxLength(200);
        entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");
        entity.Property(e => e.ConcurrencyStamp).IsConcurrencyToken();
        entity.Property(e => e.UserName).HasMaxLength(255);
        entity.Property(e => e.Email).HasMaxLength(255);
        entity.Property(e => e.NormalizedEmail).HasMaxLength(255);


        entity.HasIndex(e => e.IdRoleCompte, "idRoleCompte");

        entity.HasIndex(e => e.IdTypeEntreprise, "idTypeEntreprise");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.AdresseFacturation)
            .IsRequired()
            .HasMaxLength(300)
            .HasColumnName("adresseFacturation");

        entity.Property(e => e.CodePostalFacturation)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("codePostalFacturation");

        entity.Property(e => e.EstValider)
            .HasMaxLength(1)
            .HasColumnName("estValider")
            .HasDefaultValueSql("'0'")
            .IsFixedLength(true);

        entity.Property(e => e.IdRoleCompte).HasColumnName("idRoleCompte");

        entity.Property(e => e.IdTypeEntreprise).HasColumnName("idTypeEntreprise");

        entity.Property(e => e.Mail)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("mail");

        entity.Property(e => e.MailFacturation)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("mailFacturation");

        entity.Property(e => e.Mdp)
            .IsRequired()
            .HasMaxLength(300)
            .HasColumnName("mdp");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("nom");

        entity.Property(e => e.NomEntreprise)
            .IsRequired()
            .HasMaxLength(300)
            .HasColumnName("nomEntreprise");

        entity.Property(e => e.Prenom)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("prenom");

        entity.Property(e => e.ReductionPrix)
            .HasColumnName("reductionPrix")
            .HasDefaultValueSql("'0'");

        entity.Property(e => e.RefreshToken)
            .HasMaxLength(200)
            .HasColumnName("refreshToken");

        entity.Property(e => e.Tel)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("tel");

        entity.Property(e => e.TelFacturation)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("telFacturation");

        entity.Property(e => e.VilleFacturation)
            .IsRequired()
            .HasMaxLength(300)
            .HasColumnName("villeFacturation");

        entity.HasOne(d => d.IdRoleCompteNavigation)
            .WithMany(p => p.Comptes)
            .HasForeignKey(d => d.IdRoleCompte)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("compte_ibfk_1");

        entity.HasOne(d => d.TypeEntreprise)
            .WithMany(p => p.Comptes)
            .HasForeignKey(d => d.IdTypeEntreprise)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("compte_ibfk_2");

        return entity;
    }
}
