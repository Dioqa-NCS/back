using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Tickets;
public static class TicketConfiguration
{

    public static EntityTypeBuilder<Ticket> Configure(this EntityTypeBuilder<Ticket> entity)
    {
        entity.ToTable("ticket");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.DateHeureEnvoie).HasColumnName("dateHeureEnvoie");

        entity.Property(e => e.Mail)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("mail");

        entity.Property(e => e.Message)
            .IsRequired()
            .HasMaxLength(2000)
            .HasColumnName("message");

        entity.Property(e => e.Nom)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("nom");

        entity.Property(e => e.NomEntreprise)
            .IsRequired()
            .HasMaxLength(300)
            .HasColumnName("nomEntreprise");

        entity.Property(e => e.Prenom)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("prenom");

        entity.Property(e => e.Sujet)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("sujet");

        entity.Property(e => e.Telephone)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("telephone");

        return entity;
    }
}
