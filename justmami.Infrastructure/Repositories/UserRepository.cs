using justmami.Domain.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace justmami.Infrastructure.Repositories;
public class UserRepository : IRepository<User>
{
    private readonly Context _context;

    public UserRepository()
    {
        _context = new Context();
    }

    public async Task<User> AddAsync(User entity)
    {
        //Check if user exists
        User u = _context.Users.FirstOrDefault(x => x.Email == entity.Email);
        if (u != null)
        {
            return null;
        }

        entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);

        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public IQueryable<User> Find(Expression<Func<User, Boolean>> predicate) => throw new NotImplementedException();
    public async Task<User> VerifyUser(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            return user;
        return null;
    }
    public Task<IEnumerable<User>> GetAllAsync() => throw new NotImplementedException();
    public Task<User> GetByIdAsync(Guid id) => throw new NotImplementedException();
    public Task RemoveAsync(User entity) => throw new NotImplementedException();
    public async Task UpdateAsync(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
    }
    Task IRepository<User>.AddAsync(User entity) => throw new NotImplementedException();
}
