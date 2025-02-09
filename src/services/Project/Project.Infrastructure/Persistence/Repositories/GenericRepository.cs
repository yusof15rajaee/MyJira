using Microsoft.EntityFrameworkCore;
using Project.Domain.Aggregates;
using Project.Domain.Repositories;

namespace Project.Infrastructure.Persistence.Repositories;
public class GenericRepository<T>:IGenericRepository<T> where T : AggregateRoot
{
    protected readonly ProjectDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(ProjectDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

    public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);
}
