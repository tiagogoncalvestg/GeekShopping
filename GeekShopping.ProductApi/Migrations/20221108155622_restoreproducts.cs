using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductApi.Migrations
{
    public partial class restoreproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("04f46e44-ee42-4abc-93b0-35c76b5268e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("506c222d-e6a0-42ea-971d-67698327ec8e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e0bea88-574e-470e-977c-d1d5277964f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("945300de-1e0e-4a8b-8799-ad43cb43d471"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a92e9ae1-7d05-422a-ad21-16db8b65080e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1bb452-cce8-4bf4-9803-089e95db8b7a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ab23084b-5eec-4bfd-bd80-29c59f63a5bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("abd61499-dc36-4207-894a-86b3448a745a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac85ce1a-6216-403a-a2ba-a57ee5d74b76"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b03af62f-c3e4-4c0c-912d-b6a3aaf37f0d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e59723d4-8b69-4874-a2b1-e6d1a65ad9c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f794a098-5e10-4271-9f7a-c95efa272ce9"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("5c3ee048-6cdb-4c2f-bcd4-d86b9481cdca"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/13_dragon_ball.jpg", "Camiseta Goku Fases", 59.99m },
                    { new Guid("635acddd-2a96-4619-8f3a-c9a21510dbf5"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spacex.jpg?raw=true", "Camiseta SpaceX", 49.99m },
                    { new Guid("65af9425-3816-45a4-9b47-d211857423c9"), "Action Figure", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true", "Capacete Darth Vader Star Wars Black Series", 999.99m },
                    { new Guid("682f53f0-6611-4ce3-8de2-f4592de5dafd"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_coffee.jpg?raw=true", "Camiseta Feminina Coffee Benefits", 69.9m },
                    { new Guid("73bded1d-2c86-4bae-bef6-f0a539e9d20d"), "Action Figure", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true", "Star Wars Mission Fleet Han Solo Nave Milennium Falcon", 359.99m },
                    { new Guid("7da48a83-86ef-43ce-ad83-cf6584fca047"), "Action Figure", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/4_storm_tropper.jpg?raw=true", "Star Wars The Black Series Hasbro - Stormtrooper Imperial", 189.99m },
                    { new Guid("858ece83-8a6c-4237-b54a-032c9303ae2b"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_gnu_linux.jpg?raw=true", "Camiseta GNU Linux Programador Masculina", 59.99m },
                    { new Guid("90a04a38-98b6-4e8b-adb5-7d436acf742e"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true", "Camiseta No Internet", 69.9m },
                    { new Guid("92cb96a1-a95d-4c70-82f5-d7497cffbbca"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_mars.jpg?raw=true", "Camiseta Elon Musk Spacex Marte Occupy Mars", 59.99m },
                    { new Guid("99df6b87-5002-4f8a-a43b-3344c8b9a852"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg?raw=true", "Camiseta Gamer", 69.99m },
                    { new Guid("a6acb5f3-e651-4049-99c5-87417bdfa144"), "Sweatshirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true", "Moletom Com Capuz Cobra Kai", 159.9m },
                    { new Guid("f752c172-7de4-4786-9f0b-8edf0b50a102"), "Book", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_neil.jpg?raw=true", "Livro Star Talk – Neil DeGrasse Tyson", 49.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5c3ee048-6cdb-4c2f-bcd4-d86b9481cdca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("635acddd-2a96-4619-8f3a-c9a21510dbf5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65af9425-3816-45a4-9b47-d211857423c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("682f53f0-6611-4ce3-8de2-f4592de5dafd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73bded1d-2c86-4bae-bef6-f0a539e9d20d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7da48a83-86ef-43ce-ad83-cf6584fca047"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("858ece83-8a6c-4237-b54a-032c9303ae2b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90a04a38-98b6-4e8b-adb5-7d436acf742e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("92cb96a1-a95d-4c70-82f5-d7497cffbbca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99df6b87-5002-4f8a-a43b-3344c8b9a852"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a6acb5f3-e651-4049-99c5-87417bdfa144"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f752c172-7de4-4786-9f0b-8edf0b50a102"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("04f46e44-ee42-4abc-93b0-35c76b5268e2"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spacex.jpg?raw=true", "Camiseta SpaceX", 49.99m },
                    { new Guid("506c222d-e6a0-42ea-971d-67698327ec8e"), "Action Figure", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/4_storm_tropper.jpg?raw=true", "Star Wars The Black Series Hasbro - Stormtrooper Imperial", 189.99m },
                    { new Guid("7e0bea88-574e-470e-977c-d1d5277964f0"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/13_dragon_ball.jpg", "Camiseta Goku Fases", 59.99m },
                    { new Guid("945300de-1e0e-4a8b-8799-ad43cb43d471"), "Action Figure", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true", "Capacete Darth Vader Star Wars Black Series", 999.99m },
                    { new Guid("a92e9ae1-7d05-422a-ad21-16db8b65080e"), "Sweatshirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true", "Moletom Com Capuz Cobra Kai", 159.9m },
                    { new Guid("aa1bb452-cce8-4bf4-9803-089e95db8b7a"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true", "Camiseta No Internet", 69.9m },
                    { new Guid("ab23084b-5eec-4bfd-bd80-29c59f63a5bc"), "Action Figure", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true", "Star Wars Mission Fleet Han Solo Nave Milennium Falcon", 359.99m },
                    { new Guid("abd61499-dc36-4207-894a-86b3448a745a"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg?raw=true", "Camiseta Gamer", 69.99m },
                    { new Guid("ac85ce1a-6216-403a-a2ba-a57ee5d74b76"), "Book", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_neil.jpg?raw=true", "Livro Star Talk – Neil DeGrasse Tyson", 49.9m },
                    { new Guid("b03af62f-c3e4-4c0c-912d-b6a3aaf37f0d"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_coffee.jpg?raw=true", "Camiseta Feminina Coffee Benefits", 69.9m },
                    { new Guid("e59723d4-8b69-4874-a2b1-e6d1a65ad9c9"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_gnu_linux.jpg?raw=true", "Camiseta GNU Linux Programador Masculina", 59.99m },
                    { new Guid("f794a098-5e10-4271-9f7a-c95efa272ce9"), "T-shirt", "", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_mars.jpg?raw=true", "Camiseta Elon Musk Spacex Marte Occupy Mars", 59.99m }
                });
        }
    }
}
