using System.Linq.Expressions;
using Anidream.Api.Application.Core;
using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Anidream.Api.Application.Repositories;

//Сделать 
public abstract class BaseRepository<TEntity> where TEntity : class
{
    private readonly IDbContext _dbContext;

    protected BaseRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    protected IQueryable<TEntity> FindAll(bool tracking) =>
        tracking 
            ? _dbContext.Set<TEntity>()
            : _dbContext.Set<TEntity>().AsNoTracking();
    
    protected IQueryable<TEntity> FindByExpression(Expression<Func<TEntity, bool>> expression, bool tracking)  =>
        FindAll(tracking).Where(expression);

    protected void Create(TEntity entity) =>
        _dbContext.Set<TEntity>().Add(entity);
    
    protected ValueTask<EntityEntry<TEntity>> CreateAsync(TEntity entity) =>
        _dbContext.Set<TEntity>().AddAsync(entity);

    protected void Delete(TEntity entity) =>
        _dbContext.Set<TEntity>().Remove(entity);
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}