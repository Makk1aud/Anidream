namespace Anidream.Api.Application.Shared.Entities;

public record PaginationMetadata(
    int Page,
    int PageSize,
    int TotalPages,
    int TotalCount,
    bool HasPreviousPage,
    bool HasNextPage)
{ }