using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Application.Options;

public class StorageOptions
{
    public const string SectionName = "Storage";
    
    [Required]
    public string StorageBasePath { get; set; }
    
    [Required]
    public string ImageFolder { get; set; }
    
    [Required]
    public string VideoFolder { get; set; }
}