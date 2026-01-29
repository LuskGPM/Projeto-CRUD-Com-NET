using Database.service;
using Microsoft.EntityFrameworkCore;

namespace BaseService.Service;

public class BaseService<T> where T : class
{
    protected readonly DatabaseContext _db;
    protected readonly DbSet<T> _dbSet;

    public BaseService(DatabaseContext db)
    {
        _db = db;
        _dbSet = _db.Set<T>();
    }

    public virtual async Task<IResult> CreateAsync(T entity) => TypedResults.Conflict();

    public virtual async Task<IResult> GetAllAsync()
    {
        var allitems = await _dbSet.ToListAsync();
        return TypedResults.Ok(allitems);
    }

    public virtual async Task<IResult> GetByIdAsync(int Id)
    {
        var item = await _dbSet.FindAsync(Id);
        if (item is null) return TypedResults.NotFound();
        return TypedResults.Ok(item);
    }

    public virtual async Task<IResult> DeleteAsync(int Id) => TypedResults.Conflict();

    public virtual async Task<IResult> UpdateAsync(T entity) => TypedResults.Conflict();
}