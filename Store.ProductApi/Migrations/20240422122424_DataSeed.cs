using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("07d4ff45-a4b3-4cd3-8e09-44a5e1e66b8c"), "T-shirt", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_coffee.jpg?raw=true", "Camiseta Feminina Coffee Benefits", 69.9m },
                    { new Guid("675eafa6-33ee-4c37-b18d-74040def14f9"), "T-shirt", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg?raw=true", "Camiseta Gamer", 69.99m },
                    { new Guid("6c93f102-65bc-4b34-9217-401f5f1f6940"), "Action Figure", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true", "Star Wars Mission Fleet Han Solo Nave Milennium Falcon", 359.99m },
                    { new Guid("82d18646-279d-4989-a084-57288b702123"), "Sweatshirt", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true", "Moletom Com Capuz Cobra Kai", 159.9m },
                    { new Guid("8cd2629e-67fc-4d81-b283-fab42e2698ac"), "T-shirt", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_gnu_linux.jpg?raw=true", "Camiseta GNU Linux Programador Masculina", 59.99m },
                    { new Guid("96f5fb5d-57b7-46dc-8c7f-5e0a04aca09b"), "T-shirt", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_mars.jpg?raw=true", "Camiseta Elon Musk Spacex Marte Occupy Mars", 59.99m },
                    { new Guid("9a472b1f-8bbb-4c54-b353-1a77811aa490"), "Action Figure", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/4_storm_tropper.jpg?raw=true", "Star Wars The Black Series Hasbro - Stormtrooper Imperial", 189.99m },
                    { new Guid("9bce37a3-985e-4eb2-8043-bea5ef83ee9e"), "Book", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_neil.jpg?raw=true", "Livro Star Talk – Neil DeGrasse Tyson", 49.9m },
                    { new Guid("9d6bcf0d-5478-420e-beb8-de98111b89e2"), "T-shirt", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true", "Camiseta No Internet", 69.9m },
                    { new Guid("c29c440a-080c-4e16-bb9c-ed7effa2632d"), "Action Figure", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true", "Capacete Darth Vader Star Wars Black Series", 999.99m },
                    { new Guid("d9aea7cd-9124-4642-8392-749b0061b64e"), "T-shirt", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/13_dragon_ball.jpg?raw=true", "Camiseta Goku Fases", 59.99m },
                    { new Guid("ef3e0b60-125e-4662-88c1-fe8d13b4afd7"), "T-shirt", "Quisque at urna sapien. Maecenas placerat tincidunt nibh, sed fringilla nibh tempus eget. Nullam vitae nisi sit amet erat mattis lacinia vitae ut nisi. Pellentesque tortor mauris, maximus sed tincidunt in, vehicula ut tellus. Duis mollis leo a elit mollis, sed efficitur risus mollis. Sed congue condimentum erat et maximus. Praesent porttitor et enim vel rutrum. Nunc vitae ipsum ut dui congue tincidunt. Aenean at purus non arcu maximus rhoncus non id nisi.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spacex.jpg?raw=true", "Camiseta SpaceX", 49.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("07d4ff45-a4b3-4cd3-8e09-44a5e1e66b8c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("675eafa6-33ee-4c37-b18d-74040def14f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c93f102-65bc-4b34-9217-401f5f1f6940"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("82d18646-279d-4989-a084-57288b702123"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8cd2629e-67fc-4d81-b283-fab42e2698ac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96f5fb5d-57b7-46dc-8c7f-5e0a04aca09b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a472b1f-8bbb-4c54-b353-1a77811aa490"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9bce37a3-985e-4eb2-8043-bea5ef83ee9e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d6bcf0d-5478-420e-beb8-de98111b89e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c29c440a-080c-4e16-bb9c-ed7effa2632d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9aea7cd-9124-4642-8392-749b0061b64e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef3e0b60-125e-4662-88c1-fe8d13b4afd7"));
        }
    }
}
