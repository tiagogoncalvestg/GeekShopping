using GeekShopping.CouponApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponApi.Models.Contexts;

public class MyContext : DbContext
{

    public MyContext(DbContextOptions<MyContext> options):base(options)
    {

    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.Entity<Coupon>().HasData(new Coupon
    //    {
    //        Id = Guid.NewGuid(),
    //        CouponCode = "COUPON_001",
    //        DiscountAmount = 10
    //    });

    //    modelBuilder.Entity<Coupon>().HasData(new Coupon
    //    {
    //        Id = Guid.NewGuid(),
    //        CouponCode = "COUPON_002",
    //        DiscountAmount = 15
    //    });
    //}

    public DbSet<Coupon> Coupons { get; set; }

   
    


}
