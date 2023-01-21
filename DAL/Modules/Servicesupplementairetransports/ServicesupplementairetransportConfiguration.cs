using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Servicesupplementairetransports;
public static class ServicesupplementairetransportConfiguration
{
    public static EntityTypeBuilder<Servicesupplementairetransport> Configure(this EntityTypeBuilder<Servicesupplementairetransport> entity)
    {
        entity.HasKey(e => new { e.IdTransport, e.IdSupplement })
                .HasName("PRIMARY");

        entity.ToTable("servicesupplementairetransport");

        entity.Property(e => e.IdTransport).HasColumnName("idTransport");

        entity.Property(e => e.IdSupplement).HasColumnName("idSupplement");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("nom");

        entity.Property(e => e.Prix)
            .HasColumnType("decimal(5,2)")
            .HasColumnName("prix");

        entity.HasOne(d => d.IdTransportNavigation)
            .WithMany(p => p.Servicesupplementairetransports)
            .HasForeignKey(d => d.IdTransport)
            .HasConstraintName("serviceSupplementaireTransport_ibfk_1");

        return entity;
    }
}
