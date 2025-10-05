using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Application.Shared.Entities;

public class MediaFilter
{
    [MaxLength(250)]
    public string Title {get; set;} = string.Empty; 
    
    [MaxLength(250)]
    public string Alias {get; set;} = string.Empty; 
    
    public DateOnly? MinReleaseDate {get; set;} = null;
    
    public DateOnly? MaxReleaseDate {get; set;} = null;

    [Range(0.0, 10.0)]
    public double MinRating { get; set; } = 0;
    
    [Range(0.0, 10.0)]
    public double MaxRating { get; set; } = 10;
    
    public bool IsDeleted { get; set; } = false;
    
    public List<string> GenresAliases { get; set; } = new List<string>();
}