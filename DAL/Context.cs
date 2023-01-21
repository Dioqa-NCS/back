using DAL.Modules.Adresses;
using DAL.Modules.Adressetransports;
using DAL.Modules.Comptes;
using DAL.Modules.IdentitityRoles;
using DAL.Modules.IdentityUserLogins;
using DAL.Modules.IdentityUserRoles;
using DAL.Modules.IdentityUserTokens;
using DAL.Modules.Marques;
using DAL.Modules.Rolecomptes;
using DAL.Modules.Servicesupplementaires;
using DAL.Modules.Servicesupplementairetransports;
using DAL.Modules.Statuttransports;
using DAL.Modules.Tarifs;
using DAL.Modules.Tickets;
using DAL.Modules.Transports;
using DAL.Modules.Typeentreprises;
using DAL.Modules.Typemoteurs;
using DAL.Modules.Typevehicules;
using DAL.Modules.Vehicules;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL;

public partial class Context : IdentityDbContext<Compte, IdentityRole<int>, int>
{
    public Context()
    {
    }

    public Context(DbContextOptions<NCSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adresse> Adresses { get; set; }
    public virtual DbSet<Adressetransport> Adressetransports { get; set; }
    public virtual DbSet<Compte> Comptes { get; set; }
    public virtual DbSet<Marque> Marques { get; set; }
    public virtual DbSet<Rolecompte> Rolecomptes { get; set; }
    public virtual DbSet<Servicesupplementaire> Servicesupplementaires { get; set; }
    public virtual DbSet<Servicesupplementairetransport> Servicesupplementairetransports { get; set; }
    public virtual DbSet<Statuttransport> Statuttransports { get; set; }
    public virtual DbSet<Tarif> Tarifs { get; set; }
    public virtual DbSet<Ticket> Tickets { get; set; }
    public virtual DbSet<Transport> Transports { get; set; }
    public virtual DbSet<Typeentreprise> Typeentreprises { get; set; }
    public virtual DbSet<Typemoteur> Typemoteurs { get; set; }
    public virtual DbSet<Typevehicule> Typevehicules { get; set; }
    public virtual DbSet<Vehicule> Vehicules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Adressetransport>(entity =>
        {
            entity.Configure();
        });


        modelBuilder.Entity<IdentityRole<int>>(entity =>
         {
             entity.Configure().Seed();
         });

        modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<IdentityUserRole<int>>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<IdentityUserToken<int>>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Compte>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Marque>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Rolecompte>(entity =>
        {
            entity.Configure().Seed();
        });

        modelBuilder.Entity<Servicesupplementaire>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Servicesupplementairetransport>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Statuttransport>(entity =>
        {
            entity.Configure().Seed();
        });


        modelBuilder.Entity<Tarif>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Typeentreprise>(entity =>
        {
            entity.Configure().Seed();
        });

        modelBuilder.Entity<Typemoteur>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Typevehicule>(entity =>
        {
            entity.Configure();
        });

        modelBuilder.Entity<Vehicule>(entity =>
        {
            entity.Configure();
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
