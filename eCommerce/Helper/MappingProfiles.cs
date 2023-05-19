using AutoMapper;
using eCommerce.DTOs;
using eCommerce.Entities;

namespace eCommerce.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>().
                ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name)).
                ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name)).
                ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

        }
    }
}
