using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Application.UseCases.Options;

public class PaginationOptions
{
    [Range(1, int.MaxValue)] 
    public int PageNumber { get; set; } = 1;
    
    [Range(5, 30)] 
    public int PageSize { get; set; } = 10;
}
