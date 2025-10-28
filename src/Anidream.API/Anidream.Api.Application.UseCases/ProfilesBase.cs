using Anidream.Api.Application.Utils.Dtos;
using Anidream.Api.Domain.Entities;
using AutoMapper;

namespace Anidream.Api.Application.Utils;

public class ProfilesBase : Profile
{
    public ProfilesBase()
    {
        //Media
        CreateMap<Media, MediaDto>().ReverseMap();
        CreateMap<Media, MediaForCreationDto>().ReverseMap();
        CreateMap<Media, MediaForUpdateDto>()
            .ReverseMap()
            .ForAllMembers(opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
        
        //Studio
        CreateMap<Studio, StudioDto>().ReverseMap();
        
        //Director
        CreateMap<Director, DirectorDto>().ReverseMap();
        
        //Genre
        CreateMap<Genre, GenreDto>().ReverseMap();
    }
}