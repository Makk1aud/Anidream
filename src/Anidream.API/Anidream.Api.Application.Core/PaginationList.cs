using System.Collections;

namespace Anidream.Api.Application.Core;

public class PaginationList<TEntity> : IReadOnlyCollection<TEntity>
{
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int Count { get; }
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
    
    private readonly IList<TEntity> _entities;
    
    public PaginationList(IReadOnlyCollection<TEntity> items, int page, int pageSize)
    {
        Count = items.Count;
        Page = page;
        PageSize = pageSize;
    }
    
    public IEnumerator<TEntity> GetEnumerator()
    {
        return _entities.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}