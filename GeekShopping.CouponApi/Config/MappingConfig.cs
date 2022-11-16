using AutoMapper;
using GeekShopping.CouponApi.Data.Dtos;
using GeekShopping.CouponApi.Models;

namespace GeekShopping.CouponApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
