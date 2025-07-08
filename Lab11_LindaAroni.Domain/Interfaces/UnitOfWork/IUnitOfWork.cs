using Lab11_LindaAroni.Domain.Entities;
using Lab11_LindaAroni.Domain.Interfaces.Repositories;

namespace Lab11_LindaAroni.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    IGenericRepository<User, Guid> Usuarios { get; }
    IGenericRepository<Role, Guid> Roles { get; }
    IGenericRepository<UserRole, Guid> UserRoles { get; }
    IGenericRepository<Ticket, Guid> Tickets { get; }
    IGenericRepository<Response, Guid> Responses { get; }

    Task<int> SaveAsync();
}