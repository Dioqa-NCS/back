using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class SeedingRolCompte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d45fe6af-6e1b-46f6-ae74-146048f1a11b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "46ca547b-ae33-484d-b765-f7844b303662");

            migrationBuilder.InsertData(
                table: "rolecompte",
                columns: new[] { "id", "nom" },
                values: new object[,]
                {
                    { 1, "Administrateur" },
                    { 2, "Client" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "rolecompte",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "rolecompte",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d0849396-c9bb-4a01-b4f4-1e5f9507564d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "186815cf-e165-4ee7-8de9-f484988ced5e");
        }
    }
}
