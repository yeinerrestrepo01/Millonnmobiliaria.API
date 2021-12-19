using Microsoft.EntityFrameworkCore.Migrations;

namespace Millon.Inmobiliaria.Infrastructure.Migrations
{
    public partial class Add_FK_propertyTrace_MoneyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMoneyType",
                table: "PropertyTrace",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTrace_IdMoneyType",
                table: "PropertyTrace",
                column: "IdMoneyType");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTrace_MoneyType_IdMoneyType",
                table: "PropertyTrace",
                column: "IdMoneyType",
                principalTable: "MoneyType",
                principalColumn: "IdMoneyType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTrace_MoneyType_IdMoneyType",
                table: "PropertyTrace");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTrace_IdMoneyType",
                table: "PropertyTrace");

            migrationBuilder.DropColumn(
                name: "IdMoneyType",
                table: "PropertyTrace");
        }
    }
}
