using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Models.Contexts;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MyContext context;
        private readonly UserManager<ApplicationUser> user;
        private readonly RoleManager<IdentityRole> role;

        public DbInitializer(MyContext context,
            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role)
        {
            this.context = context;
            this.user = user;
            this.role = role;
        }
         public void Initializer()
        {
            if (role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;

            role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin))
                .GetAwaiter().GetResult();
            role.CreateAsync(new IdentityRole(IdentityConfiguration.Client))
                .GetAwaiter().GetResult();

            ApplicationUser admin = new()
            {
                UserName = "tiago-admin",
                Email = "tiago-admin@teste.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (34) 12345-6789",
                FirstName = "Tiago",
                LastName = "Admin"
            };

            user.CreateAsync(admin, "Ti@go1234").GetAwaiter().GetResult();
            user.AddToRoleAsync(admin, 
                IdentityConfiguration.Admin).GetAwaiter().GetResult();
            var adminClaims = user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client = new()
            {
                UserName = "tiago-client",
                Email = "tiago-client@teste.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (34) 12345-6789",
                FirstName = "Tiago",
                LastName = "Client"
            };

            user.CreateAsync(client, "Ti@go1234").GetAwaiter().GetResult();
            user.AddToRoleAsync(client,
                IdentityConfiguration.Client).GetAwaiter().GetResult();
            var clientClaims = user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
