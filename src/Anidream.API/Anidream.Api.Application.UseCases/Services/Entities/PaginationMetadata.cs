namespace Anidream.Api.Application.UseCases.Services.Entities;

public record PaginationMetadata(
    int Page,
    int PageSize,
    int TotalPages,
    int TotalCount,
    bool HasPreviousPage,
    bool HasNextPage)
{ }