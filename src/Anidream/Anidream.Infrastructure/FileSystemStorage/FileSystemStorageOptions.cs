using System.ComponentModel.DataAnnotations;

namespace Anidream.Infrastructure;

public class FileSystemStorageOptions
{
    public const string SectionName = "Storage";
    
    [Required]
    public string StorageBasePath { get; set; }
    
    [Required]
    public string ImageFolder { get; set; }
    
    [Required]
    public string VideoFolder { get; set; }
}