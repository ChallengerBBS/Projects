using AutoMapper;
using ProductShop.Dto;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<Product, ProductDetailsDto>();

            CreateMap<User, SoldProductsDto>()
                .ForMember(x => x.Count,
                           y => y.MapFrom(u => u.ProductsSold
                                                     .Where(ps => ps.Buyer != null)
                                                     .Count()))

                .ForMember(x => x.Products,
                           y => y.MapFrom(p => p.ProductsSold
                                               .Where(ps => ps.Buyer != null)));
            CreateMap<User, UserDetailsDto>()
                .ForMember(x => x.SoldProducts,
                           y => y.MapFrom(ps => ps));
               


        }
    }
}
