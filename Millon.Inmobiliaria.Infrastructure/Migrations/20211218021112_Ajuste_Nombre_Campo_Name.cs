using Microsoft.EntityFrameworkCore.Migrations;

namespace Millon.Inmobiliaria.Infrastructure.Migrations
{
    public partial class Ajuste_Nombre_Campo_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nambe",
                table: "Owner",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Owner",
                newName: "Nambe");
        }
    }
}
