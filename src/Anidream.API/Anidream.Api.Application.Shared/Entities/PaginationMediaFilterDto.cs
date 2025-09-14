namespace Anidream.Api.Application.Shared.Entities;

public record PaginationMediaFilterDto(PaginationOptions paginationOptions, MediaFilter? mediaFilter = null)
{
    
}