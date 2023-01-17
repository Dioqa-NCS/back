using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations;

public partial class firstMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "adressetransport",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                mailContact = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                telContact = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                nomContact = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                pays = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                ville = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                codePostal = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                adresse = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                longitude = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                latitude = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_adressetransport", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "marque",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_marque", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "rolecompte",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_rolecompte", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "servicesupplementaire",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nom = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                prix = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_servicesupplementaire", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "statuttransport",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                couleurHex = table.Column<string>(type: "char(7)", fixedLength: true, maxLength: 7, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_statuttransport", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "tarif",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                intervalKmMin = table.Column<int>(type: "int", nullable: false),
                intervalKmMax = table.Column<int>(type: "int", nullable: false),
                prixAllerSimple = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                prixAllerRetour = table.Column<decimal>(type: "decimal(6,2)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_tarif", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "ticket",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nomEntreprise = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                nom = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                prenom = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                telephone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                sujet = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                mail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                dateHeureEnvoie = table.Column<DateTime>(type: "datetime", nullable: false),
                message = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ticket", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "typeentreprise",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_typeentreprise", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "typemoteur",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_typemoteur", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "typevehicule",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                nom = table.Column<string>(type: "char(1)", fixedLength: true, maxLength: 1, nullable: false),
                description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                coefficiant = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_typevehicule", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "compte",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                idRoleCompte = table.Column<int>(type: "int", nullable: false),
                idTypeEntreprise = table.Column<int>(type: "int", nullable: false),
                nom = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                prenom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                mail = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                tel = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                mdp = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                nomEntreprise = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                refreshToken = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                adresseFacturation = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                villeFacturation = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                codePostalFacturation = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                telFacturation = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                mailFacturation = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                reductionPrix = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'0'"),
                estValider = table.Column<string>(type: "char(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "'0'")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_compte", x => x.id);
                table.ForeignKey(
                    name: "compte_ibfk_1",
                    column: x => x.idRoleCompte,
                    principalTable: "rolecompte",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "compte_ibfk_2",
                    column: x => x.idTypeEntreprise,
                    principalTable: "typeentreprise",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "adresse",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                idCompte = table.Column<int>(type: "int", nullable: true),
                nom = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                mailContact = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                telContact = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                nomContact = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                pays = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                ville = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                codePostal = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                adresse = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                longitude = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                latitude = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_adresse", x => x.id);
                table.ForeignKey(
                    name: "adresse_ibfk_1",
                    column: x => x.idCompte,
                    principalTable: "compte",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "vehicule",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                idTypeVehicule = table.Column<int>(type: "int", nullable: false),
                idTypeMoteur = table.Column<int>(type: "int", nullable: false),
                idCompte = table.Column<int>(type: "int", nullable: false),
                plaqueImatriculation = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                numeroVIN = table.Column<string>(type: "char(8)", fixedLength: true, maxLength: 8, nullable: false),
                nomMarque = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                nomModel = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                nomCarburant = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_vehicule", x => x.id);
                table.ForeignKey(
                    name: "vehicule_ibfk_1",
                    column: x => x.idTypeVehicule,
                    principalTable: "typevehicule",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "vehicule_ibfk_2",
                    column: x => x.idTypeMoteur,
                    principalTable: "typemoteur",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "vehicule_ibfk_3",
                    column: x => x.idCompte,
                    principalTable: "compte",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "transport",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                idCompte = table.Column<int>(type: "int", nullable: false),
                idVehiculeLivraison = table.Column<int>(type: "int", nullable: true),
                idVehiculeReprise = table.Column<int>(type: "int", nullable: true),
                typeTransport = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                idStatutTransport = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                idAdresseDebut = table.Column<int>(type: "int", nullable: false),
                idAdresseFin = table.Column<int>(type: "int", nullable: false),
                dateDebut = table.Column<DateTime>(type: "date", nullable: false),
                dateFin = table.Column<DateTime>(type: "date", nullable: false),
                commentaire = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                distanceKm = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                prixTotal = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                reference = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                bonCommande = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_transport", x => x.id);
                table.ForeignKey(
                    name: "transport_ibfk_1",
                    column: x => x.idCompte,
                    principalTable: "compte",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "transport_ibfk_2",
                    column: x => x.idVehiculeLivraison,
                    principalTable: "vehicule",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "transport_ibfk_3",
                    column: x => x.idVehiculeReprise,
                    principalTable: "vehicule",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "transport_ibfk_4",
                    column: x => x.idStatutTransport,
                    principalTable: "statuttransport",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "transport_ibfk_5",
                    column: x => x.idAdresseDebut,
                    principalTable: "adressetransport",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "transport_ibfk_6",
                    column: x => x.idAdresseFin,
                    principalTable: "adressetransport",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "servicesupplementairetransport",
            columns: table => new
            {
                idTransport = table.Column<int>(type: "int", nullable: false),
                idSupplement = table.Column<int>(type: "int", nullable: false),
                nom = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                prix = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PRIMARY", x => new { x.idTransport, x.idSupplement });
                table.ForeignKey(
                    name: "serviceSupplementaireTransport_ibfk_1",
                    column: x => x.idTransport,
                    principalTable: "transport",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "idCompte",
            table: "adresse",
            column: "idCompte");

        migrationBuilder.CreateIndex(
            name: "idRoleCompte",
            table: "compte",
            column: "idRoleCompte");

        migrationBuilder.CreateIndex(
            name: "idTypeEntreprise",
            table: "compte",
            column: "idTypeEntreprise");

        migrationBuilder.CreateIndex(
            name: "idAdresseDebut",
            table: "transport",
            column: "idAdresseDebut");

        migrationBuilder.CreateIndex(
            name: "idAdresseFin",
            table: "transport",
            column: "idAdresseFin");

        migrationBuilder.CreateIndex(
            name: "idCompte1",
            table: "transport",
            column: "idCompte");

        migrationBuilder.CreateIndex(
            name: "idStatutTransport",
            table: "transport",
            column: "idStatutTransport");

        migrationBuilder.CreateIndex(
            name: "idVehiculeLivraison",
            table: "transport",
            column: "idVehiculeLivraison");

        migrationBuilder.CreateIndex(
            name: "idVehiculeReprise",
            table: "transport",
            column: "idVehiculeReprise");

        migrationBuilder.CreateIndex(
            name: "idCompte2",
            table: "vehicule",
            column: "idCompte");

        migrationBuilder.CreateIndex(
            name: "idTypeMoteur",
            table: "vehicule",
            column: "idTypeMoteur");

        migrationBuilder.CreateIndex(
            name: "idTypeVehicule",
            table: "vehicule",
            column: "idTypeVehicule");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "adresse");

        migrationBuilder.DropTable(
            name: "marque");

        migrationBuilder.DropTable(
            name: "servicesupplementaire");

        migrationBuilder.DropTable(
            name: "servicesupplementairetransport");

        migrationBuilder.DropTable(
            name: "tarif");

        migrationBuilder.DropTable(
            name: "ticket");

        migrationBuilder.DropTable(
            name: "transport");

        migrationBuilder.DropTable(
            name: "vehicule");

        migrationBuilder.DropTable(
            name: "statuttransport");

        migrationBuilder.DropTable(
            name: "adressetransport");

        migrationBuilder.DropTable(
            name: "typevehicule");

        migrationBuilder.DropTable(
            name: "typemoteur");

        migrationBuilder.DropTable(
            name: "compte");

        migrationBuilder.DropTable(
            name: "rolecompte");

        migrationBuilder.DropTable(
            name: "typeentreprise");
    }
}
