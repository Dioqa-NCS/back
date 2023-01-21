using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Statuttransports;
public static class StatuttransportConfiguration
{
    public static EntityTypeBuilder<Statuttransport> Configure(this EntityTypeBuilder<Statuttransport> entity)
    {
        entity.ToTable("statuttransport");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.CouleurHex)
            .IsRequired()
            .HasMaxLength(7)
            .HasColumnName("couleurHex")
            .IsFixedLength(true);

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nom");

        return entity;
    }
}
