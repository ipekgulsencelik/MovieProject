using AutoMapper;
using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Domain.Entities;

namespace Movie.WebAPI.Mappings
{
    public class SeriesMapping : Profile
    {
        public SeriesMapping()
        {
            // LIST / GET
            CreateMap<GetSeriesQueryResult, Series>().ReverseMap();
            CreateMap<GetSeriesByIdQueryResult, Series>().ReverseMap();

            // FILTERED LISTS (senin handler/result yapına göre)
            CreateMap<Series, GetPendingSeriesQueryResult>().ReverseMap();
            CreateMap<Series, GetPublishedSeriesByCategoryQueryResult>().ReverseMap();
            CreateMap<Series, GetSeriesByCategoryQueryResult>().ReverseMap();
            CreateMap<Series, GetArchivedSeriesQueryResult>().ReverseMap();
            CreateMap<Series, GetDeletedSeriesQueryResult>().ReverseMap();

            // SEARCH
            CreateMap<Series, SearchSeriesQueryResult>().ReverseMap();

            // CREATE / UPDATE
            CreateMap<CreateSeriesCommand, Series>().ReverseMap();
            CreateMap<UpdateSeriesCommand, Series>().ReverseMap();
        }
    }
}