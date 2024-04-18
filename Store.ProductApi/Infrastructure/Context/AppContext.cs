using Microsoft.EntityFrameworkCore;
using Store.ProductApi.Models;

namespace Store.ProductApi.Infrastructure.Context;

public class AppContext : DbContext
{

    public AppContext() { }
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
