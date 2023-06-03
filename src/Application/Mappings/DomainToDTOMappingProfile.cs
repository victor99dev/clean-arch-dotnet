using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<CategoryDTO, Category>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForPath(dest => dest.IsActive, opt => opt.MapFrom(src => src.is_active))
                .ForPath(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.created_at))
                .ForPath(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.updated_at))
            .ReverseMap();
             CreateMap<ProductDTO, Product>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForPath(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForPath(dest => dest.Price, opt => opt.MapFrom(src => src.price))
                .ForPath(dest => dest.Stock, opt => opt.MapFrom(src => src.stock))
                .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.image))
                .ForPath(dest => dest.CategoryId, opt => opt.MapFrom(src => src.category_id))
                .ForPath(dest => dest.Category, opt => opt.MapFrom(src => src.category))
                .ForPath(dest => dest.IsActive, opt => opt.MapFrom(src => src.is_active))
                .ForPath(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.created_at))
                .ForPath(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.updated_at))
            .ReverseMap();
        }
    }
}