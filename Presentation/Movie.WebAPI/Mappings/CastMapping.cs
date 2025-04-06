using AutoMapper;
using Movie.Application.Features.Mediator.Commands.CastCommands;
using Movie.Application.Features.Mediator.Results.CastResults;
using Movie.Domain.Entities;

namespace Movie.WebAPI.Mappings
{
    public class CastMapping : Profile
    {
        public CastMapping()
        {
            CreateMap<GetCastQueryResult, Cast>().ReverseMap();
            CreateMap<GetCastByIdQueryResult, Cast>().ReverseMap();
            CreateMap<Cast, GetActiveCastsQueryResult>().ReverseMap();
            CreateMap<Cast, GetVisibleCastsQueryResult>().ReverseMap();
            CreateMap<CreateCastCommand, Cast>().ReverseMap();
            CreateMap<UpdateCastCommand, Cast>().ReverseMap();
        }
    }
}