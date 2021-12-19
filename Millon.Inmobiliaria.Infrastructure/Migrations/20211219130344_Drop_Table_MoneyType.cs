using Microsoft.EntityFrameworkCore.Migrations;

namespace Millon.Inmobiliaria.Infrastructure.Migrations
{
    public partial class Drop_Table_MoneyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "MoneyType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
