using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Servicesupplementaires;
public static class ServicesupplementaireConfiguration
{
    public static EntityTypeBuilder<Servicesupplementaire> Configure(this EntityTypeBuilder<Servicesupplementaire> entity)
    {
        entity.ToTable("servicesupplementaire");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("nom");

        entity.Property(e => e.Prix)
            .HasColumnType("decimal(5,2)")
            .HasColumnName("prix");

        return entity;
    }
}
