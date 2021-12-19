using Microsoft.EntityFrameworkCore.Migrations;

namespace Millon.Inmobiliaria.Infrastructure.Migrations
{
    public partial class Ajuste_Relacion_PropertyNavegation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Owner_IdProperty",
                table: "PropertyImage");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Property_IdProperty",
                table: "PropertyImage",
                column: "IdProperty",
                principalTable: "Property",
                principalColumn: "IdProperty",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Property_IdProperty",
                table: "PropertyImage");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Owner_IdProperty",
                table: "PropertyImage",
                column: "IdProperty",
                principalTable: "Owner",
                principalColumn: "IdOwner",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
