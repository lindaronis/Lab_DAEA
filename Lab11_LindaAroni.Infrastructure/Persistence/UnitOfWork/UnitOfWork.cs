using Lab11_LindaAroni.Domain.Entities;
using Lab11_LindaAroni.Domain.Interfaces.Repositories;
using Lab11_LindaAroni.Domain.Interfaces.UnitOfWork;
using Lab11_LindaAroni.Infrastructure.Context;
using Lab11_LindaAroni.Infrastructure.Persistence.Repositories;

namespace Lab11_LindaAroni.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly Lab11DbContext _context;
    
    public IGenericRepository<User, Guid> Usuarios { get; }
    public IGenericRepository<Role, Guid> Roles { get; }
    public IGenericRepository<UserRole, Guid> UserRoles { get; }
    public IGenericRepository<Ticket, Guid> Tickets { get; }
    public IGenericRepository<Response, Guid> Responses { get; }

    public UnitOfWork(Lab11DbContext context)
    {
        _context = context;
        Usuarios = new GenericRepository<User, Guid>(_context);
        Roles = new GenericRepository<Role, Guid>(_context);
        UserRoles = new GenericRepository<UserRole, Guid>(_context);
        Tickets = new GenericRepository<Ticket, Guid>(_context);
        Responses = new GenericRepository<Response, Guid>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}