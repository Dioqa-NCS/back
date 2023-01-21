using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Transports;
public static class TransportConfiguration
{
    public static EntityTypeBuilder<Transport> Configure(this EntityTypeBuilder<Transport> entity)
    {
        entity.ToTable("transport");

        entity.HasIndex(e => e.IdAdresseDebut, "idAdresseDebut");

        entity.HasIndex(e => e.IdAdresseFin, "idAdresseFin");

        entity.HasIndex(e => e.IdCompte, "idCompte");

        entity.HasIndex(e => e.IdStatutTransport, "idStatutTransport");

        entity.HasIndex(e => e.IdVehiculeLivraison, "idVehiculeLivraison");

        entity.HasIndex(e => e.IdVehiculeReprise, "idVehiculeReprise");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.BonCommande)
            .HasMaxLength(80)
            .HasColumnName("bonCommande");

        entity.Property(e => e.Commentaire)
            .HasMaxLength(1000)
            .HasColumnName("commentaire");

        entity.Property(e => e.DateDebut)
            .HasColumnType("date")
            .HasColumnName("dateDebut");

        entity.Property(e => e.DateFin)
            .HasColumnType("date")
            .HasColumnName("dateFin");

        entity.Property(e => e.DistanceKm)
            .HasColumnType("decimal(10,3)")
            .HasColumnName("distanceKm");

        entity.Property(e => e.IdAdresseDebut).HasColumnName("idAdresseDebut");

        entity.Property(e => e.IdAdresseFin).HasColumnName("idAdresseFin");

        entity.Property(e => e.IdCompte).HasColumnName("idCompte");

        entity.Property(e => e.IdStatutTransport)
            .HasColumnName("idStatutTransport")
            .HasDefaultValueSql("'1'");

        entity.Property(e => e.IdVehiculeLivraison).HasColumnName("idVehiculeLivraison");

        entity.Property(e => e.IdVehiculeReprise).HasColumnName("idVehiculeReprise");

        entity.Property(e => e.PrixTotal)
            .HasColumnType("decimal(7,2)")
            .HasColumnName("prixTotal");

        entity.Property(e => e.Reference)
            .IsRequired()
            .HasMaxLength(8)
            .HasColumnName("reference");

        entity.Property(e => e.TypeTransport)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("typeTransport");

        entity.HasOne(d => d.IdAdresseDebutNavigation)
            .WithMany(p => p.TransportIdAdresseDebutNavigations)
            .HasForeignKey(d => d.IdAdresseDebut)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("transport_ibfk_5");

        entity.HasOne(d => d.IdAdresseFinNavigation)
            .WithMany(p => p.TransportIdAdresseFinNavigations)
            .HasForeignKey(d => d.IdAdresseFin)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("transport_ibfk_6");

        entity.HasOne(d => d.IdCompteNavigation)
            .WithMany(p => p.Transports)
            .HasForeignKey(d => d.IdCompte)
            .HasConstraintName("transport_ibfk_1");

        entity.HasOne(d => d.IdStatutTransportNavigation)
            .WithMany(p => p.Transports)
            .HasForeignKey(d => d.IdStatutTransport)
            .HasConstraintName("transport_ibfk_4");

        entity.HasOne(d => d.IdVehiculeLivraisonNavigation)
            .WithMany(p => p.TransportIdVehiculeLivraisonNavigations)
            .HasForeignKey(d => d.IdVehiculeLivraison)
            .HasConstraintName("transport_ibfk_2");

        entity.HasOne(d => d.IdVehiculeRepriseNavigation)
            .WithMany(p => p.TransportIdVehiculeRepriseNavigations)
            .HasForeignKey(d => d.IdVehiculeReprise)
            .HasConstraintName("transport_ibfk_3");

        return entity;
    }
}
