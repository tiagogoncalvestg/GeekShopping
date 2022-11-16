using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.CouponApi.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "Id", "coupon_code", "discount_amount" },
                values: new object[] { new Guid("6fa2e58c-6825-47d8-9413-fe226dcbd23b"), "COUPON_002", 15m });

            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "Id", "coupon_code", "discount_amount" },
                values: new object[] { new Guid("b09893f1-bfac-4242-aaa2-6609dbccdb51"), "COUPON_001", 10m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "Id",
                keyValue: new Guid("6fa2e58c-6825-47d8-9413-fe226dcbd23b"));

            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "Id",
                keyValue: new Guid("b09893f1-bfac-4242-aaa2-6609dbccdb51"));
        }
    }
}
