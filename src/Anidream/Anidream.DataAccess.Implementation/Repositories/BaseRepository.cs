using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Anidream.DataAccess.Implementation;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    private readonly AnidreamContext _dbContext;

    protected BaseRepository(AnidreamContext dbContext)
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
    
    protected ValueTask<EntityEntry<TEntity>> CreateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    
    protected TEntity Update(TEntity entity) => 
        _dbContext.Set<TEntity>().Update(entity).Entity;

    protected void Delete(TEntity entity) =>
        _dbContext.Set<TEntity>().Remove(entity);
}