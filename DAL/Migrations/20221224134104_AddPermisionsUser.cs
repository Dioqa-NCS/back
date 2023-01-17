using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations;

public partial class AddPermisionsUser : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Permissions",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Permissions", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "PermissionUser",
            columns: table => new
            {
                PermissionCollectionId = table.Column<int>(type: "int", nullable: false),
                UserCollectionId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PermissionUser", x => new { x.PermissionCollectionId, x.UserCollectionId });
                table.ForeignKey(
                    name: "FK_PermissionUser_AspNetUsers_UserCollectionId",
                    column: x => x.UserCollectionId,
                    principalTable: "AspNetUsers",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_PermissionUser_Permissions_PermissionCollectionId",
                    column: x => x.PermissionCollectionId,
                    principalTable: "Permissions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_PermissionUser_UserCollectionId",
            table: "PermissionUser",
            column: "UserCollectionId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "PermissionUser");

        migrationBuilder.DropTable(
            name: "Permissions");
    }
}
