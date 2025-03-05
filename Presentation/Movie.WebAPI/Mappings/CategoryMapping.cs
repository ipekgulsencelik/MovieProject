using AutoMapper;
using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Features.CQRS.Results.CategoryResults;
using Movie.Domain.Entities;

namespace Movie.WebAPI.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<GetCategoryQueryResult, Category>().ReverseMap();
            CreateMap<GetCategoryByIdQueryResult, Category>().ReverseMap();
            CreateMap<Category, GetActiveCategoriesQueryResult>().ReverseMap();
            CreateMap<Category, GetVisibleCategoriesQueryResult>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        }
    }
}