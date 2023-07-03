using GeekShopping.IdentityServer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Models.Contexts;

public class MyContext : IdentityDbContext<ApplicationUser>
{
	public MyContext(DbContextOptions<MyContext> options) : base(options)
	{
		Database.EnsureCreated();
	}
}
