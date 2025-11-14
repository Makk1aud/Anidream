using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Director;
using Anidream.Application.Contracts.Genre;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Contracts.Studio;
using Anidream.Domain.Entities;
using AutoMapper;

namespace Anidream.Application.UseCases;

public class ProfilesBase : Profile
{
    public ProfilesBase()
    {
        //Media
        CreateMap<Media, MediaResponse>().ReverseMap();
        CreateMap<Media, MediaForCreationRequest>().ReverseMap();
        
        CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<DateOnly?, DateOnly>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<Guid?, Guid>().ConvertUsing((src, dest) => src ?? dest);
        
        CreateMap<Media, MediaForUpdateRequest>()
            .ReverseMap()
            .ForAllMembers(opts =>
            {
                opts.AllowNull();
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
        
        //Studio
        CreateMap<Studio, StudioResponse>().ReverseMap();
        CreateMap<Studio, StudioRequest>().ReverseMap();
        
        //Director
        CreateMap<Director, DirectorResponse>().ReverseMap();
        
        //Genre
        CreateMap<Genre, GenreResponse>().ReverseMap();
        CreateMap<Genre, GenreRequest>().ReverseMap();
    }
}