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

    public Context( DbContextOptions<NCSContext> options)
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
    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Adresse>(entity =>
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
        });

        modelBuilder.Entity<Adressetransport>(entity =>
        {
            entity.ToTable("adressetransport");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Adresse)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("adresse");

            entity.Property(e => e.CodePostal)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("codePostal");

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
        });


        modelBuilder.Entity<IdentityRole<int>>( entity =>
         {
             entity.Property( m => m.NormalizedName ).HasMaxLength( 200 );
         } );

        modelBuilder.Entity<IdentityUserLogin<int>>( entity =>
        {
            entity.Property( m => m.LoginProvider ).HasMaxLength( 200 );
            entity.Property( m => m.ProviderKey ).HasMaxLength( 200 );
        } );

        modelBuilder.Entity<IdentityUserRole<int>>( entity =>
        {
            entity.Property( m => m.RoleId ).HasMaxLength( 200 );
        } );

        modelBuilder.Entity<IdentityUserToken<int>>( entity =>
        {
            entity.Property( m => m.LoginProvider ).HasMaxLength( 200 );
            entity.Property( m => m.Name ).HasMaxLength( 200 );
        });


        modelBuilder.Entity<Compte>(entity =>
        {
            entity.ToTable("compte");

            entity.HasIndex(e => e.IdRoleCompte, "idRoleCompte");

            entity.HasIndex(e => e.IdTypeEntreprise, "idTypeEntreprise");

            entity.Property( m => m.NormalizedUserName ).HasMaxLength( 200 );

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
        });

        modelBuilder.Entity<Marque>(entity =>
        {
            entity.ToTable("marque");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Rolecompte>(entity =>
        {
            entity.ToTable("rolecompte");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Servicesupplementaire>(entity =>
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
        });

        modelBuilder.Entity<Servicesupplementairetransport>(entity =>
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
        });

        modelBuilder.Entity<Statuttransport>(entity =>
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
        });

        modelBuilder.Entity<Tarif>(entity =>
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
        });

        modelBuilder.Entity<Ticket>(entity =>
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
        });

        modelBuilder.Entity<Transport>(entity =>
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
        });

        modelBuilder.Entity<Typeentreprise>(entity =>
        {
            entity.ToTable("typeentreprise");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Typemoteur>(entity =>
        {
            entity.ToTable("typemoteur");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Typevehicule>(entity =>
        {
            entity.ToTable("typevehicule");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Coefficiant).HasColumnName("coefficiant");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("description");

            entity.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("nom")
                .IsFixedLength(true);
        });

        modelBuilder.Entity<Vehicule>(entity =>
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
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
