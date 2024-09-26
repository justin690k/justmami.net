using justmami.Domain.Entities;
using justmami.Infrastructure.Core;
using System.Linq.Expressions;

namespace justmami.Infrastructure.Repositories;
public class UserRepository : IRepository<User>
{
    public Task AddAsync(User entity) => throw new NotImplementedException();
    public IQueryable<User> Find(Expression<Func<User, Boolean>> predicate) => throw new NotImplementedException();
    public Task<IEnumerable<User>> GetAllAsync() => throw new NotImplementedException();
    public Task<User> GetByIdAsync(Guid id) => throw new NotImplementedException();
    public Task RemoveAsync(User entity) => throw new NotImplementedException();
    public Task UpdateAsync(User entity) => throw new NotImplementedException();
}
