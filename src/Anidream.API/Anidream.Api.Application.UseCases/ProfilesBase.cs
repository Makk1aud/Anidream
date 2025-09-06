using Anidream.Api.Application.Utils.Dtos;
using Anidream.Api.Domain.Entities;
using AutoMapper;

namespace Anidream.Api.Application.Utils;

public class ProfilesBase : Profile
{
    public ProfilesBase()
    {
        CreateMap<Media, MediaDto>().ReverseMap();
        CreateMap<Media, MediaForCreationDto>().ReverseMap();
        CreateMap<Studio, StudioDto>().ReverseMap();
        CreateMap<Director, DirectorDto>().ReverseMap();
    }
}