using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.CartApi.Migrations
{
    public partial class correctionInCartTableLetsTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PurchaseAmount",
                table: "CartHeaders",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseAmount",
                table: "CartHeaders");
        }
    }
}
