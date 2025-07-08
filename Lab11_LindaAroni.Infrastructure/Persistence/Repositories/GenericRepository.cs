using System.Linq.Expressions;
using Lab11_LindaAroni.Domain.Interfaces.Repositories;
using Lab11_LindaAroni.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab11_LindaAroni.Infrastructure.Persistence.Repositories;

public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
{
    private readonly Lab11DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository( Lab11DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<IEnumerable<T>> FindWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.Where(predicate).ToListAsync();
    }
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}