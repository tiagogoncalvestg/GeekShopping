using AutoMapper;
using GeekShopping.CartApi.Models;
using GeekShopping.CartAPI.Data.Dtos;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                config.CreateMap<CartDto, Cart>().ReverseMap();
                config.CreateMap<CartDetail, CartDetailDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
