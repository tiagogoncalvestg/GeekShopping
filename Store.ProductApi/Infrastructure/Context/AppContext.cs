using Microsoft.EntityFrameworkCore;
using Store.ProductApi.Models;

namespace Store.ProductApi.Infrastructure.Context;

public class AppContext : DbContext
{

    public AppContext() { Database.EnsureCreated(); }
    public AppContext(DbContextOptions<AppContext> options) : base(options) { Database.EnsureCreated(); }

    public DbSet<Product> Products { get; set; }
}
