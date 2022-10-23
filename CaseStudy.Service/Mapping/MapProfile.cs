using AutoMapper;
using CaseStudy.Core;
using CaseStudy.Core.DTOs;
using CaseStudy.Core.Models;

namespace CaseStudy.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<Cart, CartWithCartItemsDto>().ReverseMap();
            CreateMap<CartItem, CartItemUpdateDto>().ReverseMap();       
            CreateMap<Product, ProductDto>();

            CreateMap<CartItemAddDto, CartItem>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId));
        }
    }
}
