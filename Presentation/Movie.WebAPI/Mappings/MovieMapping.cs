using AutoMapper;
using Movie.Application.Features.CQRS.Results.MovieResults;
using Movie.Domain.Entities;

namespace Movie.WebAPI.Mappings
{
    public class MovieMapping : Profile
    {
        public MovieMapping()
        {
            CreateMap<GetMovieQueryResult, Film>().ReverseMap();
            CreateMap<GetMovieByIdQueryResult, Film>().ReverseMap();
        }
    }
}