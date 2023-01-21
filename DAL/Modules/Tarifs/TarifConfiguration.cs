using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Tarifs;
public static class TarifConfiguration
{
    public static EntityTypeBuilder<Tarif> Configure(this EntityTypeBuilder<Tarif> entity)
    {
        entity.ToTable("tarif");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.IntervalKmMax).HasColumnName("intervalKmMax");

        entity.Property(e => e.IntervalKmMin).HasColumnName("intervalKmMin");

        entity.Property(e => e.PrixAllerRetour)
            .HasColumnType("decimal(6,2)")
            .HasColumnName("prixAllerRetour");

        entity.Property(e => e.PrixAllerSimple)
            .HasColumnType("decimal(6,2)")
            .HasColumnName("prixAllerSimple");

        return entity;
    }
}
