using Microsoft.EntityFrameworkCore;
using TicketReservation.DataAccess;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TicketReservationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(TicketReservationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
