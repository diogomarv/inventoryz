using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryZ.Infrastructure.Migrations
{
    public partial class ChangeOnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "User",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Login");
        }
    }
}
