using AutoMapper;
using Movie.Application.Features.Mediator.Commands.TagCommands;
using Movie.Application.Features.Mediator.Results.TagResults;
using Movie.Domain.Entities;

namespace Movie.WebAPI.Mappings
{
    public class TagMapping : Profile
    {
        public TagMapping()
        {
            CreateMap<GetTagQueryResult, Tag>().ReverseMap();
            CreateMap<GetTagByIdQueryResult, Tag>().ReverseMap();
            CreateMap<Tag, GetActiveTagsQueryResult>().ReverseMap();
            CreateMap<Tag, GetVisibleTagsQueryResult>().ReverseMap();
            CreateMap<CreateTagCommand, Tag>().ReverseMap();
            CreateMap<UpdateTagCommand, Tag>().ReverseMap();
        }
    }
}