namespace Anidream.Application.Contracts;

public static class PaginationListExtensions
{
    public static PaginationList<TEntity> ToPaginationList<TEntity>(
        this IQueryable<TEntity> items,
        int page,
        int pageSize,
        int totalCount)
    {
        return new PaginationList<TEntity>(items.ToList(), page, pageSize, totalCount);
    }
}