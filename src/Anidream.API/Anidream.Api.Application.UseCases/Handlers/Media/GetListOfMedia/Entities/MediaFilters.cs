using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia.Entities;

public class MediaFilters
{
    [MaxLength(250)]
    public string Title {get; set;} = string.Empty; 
    
    [MaxLength(250)]
    public string Alias {get; set;} = string.Empty; 
    
    public DateOnly MinReleaseDate {get; set;}
    
    public DateOnly MaxReleaseDate {get; set;}

    [Range(0.0, 10.0)]
    public double MinRating { get; set; } = 0;
    
    [Range(0.0, 10.0)]
    public double MaxRating { get; set; } = 10;
}