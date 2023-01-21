using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComptePermission");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompteId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRole_AspNetUsers_CompteId",
                        column: x => x.CompteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "d0849396-c9bb-4a01-b4f4-1e5f9507564d", "Administrateur", null },
                    { 2, "186815cf-e165-4ee7-8de9-f484988ced5e", "Client", null }
                });

            migrationBuilder.InsertData(
                table: "statuttransport",
                columns: new[] { "id", "couleurHex", "nom" },
                values: new object[,]
                {
                    { 1, "#323E40", "En attente de validation" },
                    { 2, "#F2A922", "Planifié" },
                    { 3, "#D98014", "En cours" },
                    { 4, "#367334", "Terminé" },
                    { 5, "#A62929", "Annulé" },
                    { 6, "#BF926B", "Expiré" }
                });

            migrationBuilder.InsertData(
                table: "typeentreprise",
                columns: new[] { "id", "nom" },
                values: new object[,]
                {
                    { 1, "EL / EIRL" },
                    { 2, "EURL" },
                    { 3, "SARL" },
                    { 4, "SA" },
                    { 5, "SAS / SASU" },
                    { 6, "SNC" },
                    { 7, "Scop" },
                    { 8, "SCA" },
                    { 9, "SCS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_CompteId",
                table: "IdentityRole",
                column: "CompteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "statuttransport",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "statuttransport",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "statuttransport",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "statuttransport",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "statuttransport",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "statuttransport",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "typeentreprise",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComptePermission",
                columns: table => new
                {
                    PermissionCollectionId = table.Column<int>(type: "int", nullable: false),
                    UserCollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptePermission", x => new { x.PermissionCollectionId, x.UserCollectionId });
                    table.ForeignKey(
                        name: "FK_ComptePermission_AspNetUsers_UserCollectionId",
                        column: x => x.UserCollectionId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComptePermission_Permissions_PermissionCollectionId",
                        column: x => x.PermissionCollectionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ComptePermission_UserCollectionId",
                table: "ComptePermission",
                column: "UserCollectionId");
        }
    }
}
