using Microsoft.EntityFrameworkCore.Migrations;

namespace Servicios.Migrations
{
    public partial class SecondMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthyday",
                table: "Autores",
                newName: "Birthday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Autores",
                newName: "Birthyday");
        }
    }
}
