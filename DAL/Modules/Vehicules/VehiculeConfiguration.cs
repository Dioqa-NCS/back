using DAL.Modules.Typeentreprises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Vehicules;
public static class VehiculeConfiguration
{
    public static EntityTypeBuilder<Vehicule> Configure(this EntityTypeBuilder<Vehicule> entity)
    {
        entity.ToTable("vehicule");

        entity.HasIndex(e => e.IdCompte, "idCompte");

        entity.HasIndex(e => e.IdTypeMoteur, "idTypeMoteur");

        entity.HasIndex(e => e.IdTypeVehicule, "idTypeVehicule");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.IdCompte).HasColumnName("idCompte");

        entity.Property(e => e.IdTypeMoteur).HasColumnName("idTypeMoteur");

        entity.Property(e => e.IdTypeVehicule).HasColumnName("idTypeVehicule");

        entity.Property(e => e.NomCarburant)
            .HasMaxLength(20)
            .HasColumnName("nomCarburant");

        entity.Property(e => e.NomMarque)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nomMarque");

        entity.Property(e => e.NomModel)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nomModel");

        entity.Property(e => e.NumeroVin)
            .IsRequired()
            .HasMaxLength(8)
            .HasColumnName("numeroVIN")
            .IsFixedLength(true);

        entity.Property(e => e.PlaqueImatriculation)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("plaqueImatriculation");

        entity.HasOne(d => d.IdCompteNavigation)
            .WithMany(p => p.Vehicules)
            .HasForeignKey(d => d.IdCompte)
            .HasConstraintName("vehicule_ibfk_3");

        entity.HasOne(d => d.IdTypeMoteurNavigation)
            .WithMany(p => p.Vehicules)
            .HasForeignKey(d => d.IdTypeMoteur)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("vehicule_ibfk_2");

        entity.HasOne(d => d.IdTypeVehiculeNavigation)
            .WithMany(p => p.Vehicules)
            .HasForeignKey(d => d.IdTypeVehicule)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("vehicule_ibfk_1");

        return entity;
    }
}
