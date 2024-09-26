using justmami.Domain.Core;
using System.Linq.Expressions;

namespace justmami.Infrastructure.Core;
public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
}
