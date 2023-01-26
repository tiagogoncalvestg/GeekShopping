using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Models.Contexts;

public class MyContext : DbContext
{
    public MyContext() { }

    public MyContext(DbContextOptions<MyContext> options):base(options)
    {

    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Camiseta No Internet",
            Price = new decimal(69.9),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true",
            CategoryName = "T-shirt"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Capacete Darth Vader Star Wars Black Series",
            Price = new decimal(999.99),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true",
            CategoryName = "Action Figure"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Star Wars The Black Series Hasbro - Stormtrooper Imperial",
            Price = new decimal(189.99),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/4_storm_tropper.jpg?raw=true",
            CategoryName = "Action Figure"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Camiseta Gamer",
            Price = new decimal(69.99),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg?raw=true",
            CategoryName = "T-shirt"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Camiseta SpaceX",
            Price = new decimal(49.99),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spacex.jpg?raw=true",
            CategoryName = "T-shirt"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Camiseta Feminina Coffee Benefits",
            Price = new decimal(69.9),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_coffee.jpg?raw=true",
            CategoryName = "T-shirt"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Moletom Com Capuz Cobra Kai",
            Price = new decimal(159.9),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true",
            CategoryName = "Sweatshirt"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Livro Star Talk – Neil DeGrasse Tyson",
            Price = new decimal(49.9),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_neil.jpg?raw=true",
            CategoryName = "Book"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Star Wars Mission Fleet Han Solo Nave Milennium Falcon",
            Price = new decimal(359.99),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true",
            CategoryName = "Action Figure"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Camiseta Elon Musk Spacex Marte Occupy Mars",
            Price = new decimal(59.99),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_mars.jpg?raw=true",
            CategoryName = "T-shirt"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Camiseta GNU Linux Programador Masculina",
            Price = new decimal(59.99),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_gnu_linux.jpg?raw=true",
            CategoryName = "T-shirt"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Name = "Camiseta Goku Fases",
            Price = new decimal(59.99),
            Description = "",
            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/13_dragon_ball.jpg?raw=true",
            CategoryName = "T-shirt"
        });
    }


}
