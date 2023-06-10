using Application.DTOs;
using Application.Products.Commands;
using AutoMapper;

namespace Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>()
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForPath(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForPath(dest => dest.Price, opt => opt.MapFrom(src => src.price))
                .ForPath(dest => dest.Stock, opt => opt.MapFrom(src => src.stock))
                .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.image))
                .ForPath(dest => dest.CategoryId, opt => opt.MapFrom(src => src.category_id))
             .ReverseMap();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}