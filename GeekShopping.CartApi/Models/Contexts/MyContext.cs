using GeekShopping.CartAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartApi.Models.Contexts;

public class MyContext : DbContext
{

    public MyContext(DbContextOptions<MyContext> options):base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<CartHeader> CartHeaders { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }

   
    


}
