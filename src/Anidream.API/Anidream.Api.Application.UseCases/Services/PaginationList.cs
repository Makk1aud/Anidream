using System.Collections;
using Anidream.Api.Application.UseCases.Services.Entities;

namespace Anidream.Api.Application.UseCases.Services;

public class PaginationList<TEntity> : IReadOnlyCollection<TEntity>
{
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int Count { get; }
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
    
    private readonly IReadOnlyCollection<TEntity> _entities;
    
    public PaginationList(IReadOnlyCollection<TEntity> items, int page, int pageSize)
    {
        Count = items.Count;
        Page = page;
        PageSize = pageSize;
        _entities = items;
        TotalPages = (int)Math.Ceiling(Count / (double)pageSize);
    }

    private IReadOnlyCollection<TEntity> ApplyPagination(IReadOnlyCollection<TEntity> items) =>
        items.Skip((Page - 1) * PageSize).Take(PageSize).ToList();

    public PaginationMetadata GetMetadata() => new
    (
        Page,
        PageSize,
        TotalPages,
        Count,
        HasPreviousPage,
        HasNextPage
    );
    
    public IEnumerator<TEntity> GetEnumerator()
    {
        return ApplyPagination(_entities).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}