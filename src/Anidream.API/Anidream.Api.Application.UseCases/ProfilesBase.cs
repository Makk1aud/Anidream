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
        
        CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<DateOnly?, DateOnly>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<Guid?, Guid>().ConvertUsing((src, dest) => src ?? dest);
        
        CreateMap<Media, MediaForUpdateDto>()
            .ReverseMap()
            .ForAllMembers(opts =>
            {
                opts.AllowNull();
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
        
        //Studio
        CreateMap<Studio, StudioDto>().ReverseMap();
        
        //Director
        CreateMap<Director, DirectorDto>().ReverseMap();
        
        //Genre
        CreateMap<Genre, GenreDto>().ReverseMap();
    }
}