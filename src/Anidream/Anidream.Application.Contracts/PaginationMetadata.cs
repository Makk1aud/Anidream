namespace Anidream.Application.Contracts;

public record PaginationMetadata(
    int Page,
    int PageSize,
    int TotalPages,
    int TotalCount,
    bool HasPreviousPage,
    bool HasNextPage)
{ }