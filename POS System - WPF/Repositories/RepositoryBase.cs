using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using POS_System___WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly DbContext _db;
    protected readonly DbSet<T> _dbSet;

    public RepositoryBase(DbContext db)
    {
        _db = db;
        _dbSet = db.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(
    object id,
    params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var inc in includes)
            query = query.Include(inc);

        var keyName = _db.Model.FindEntityType(typeof(T))!.FindPrimaryKey()!.Properties
                        .Select(x => x.Name)
                        .Single(); // assume single key

        return await query.FirstOrDefaultAsync(
            e => EF.Property<object>(e, keyName).Equals(id)
        );
    }



    public virtual async Task<IReadOnlyList<T>> ListAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int? skip = null,
        int? take = null,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        foreach (var inc in includes) query = query.Include(inc);
        if (filter != null) query = query.Where(filter);
        if (orderBy != null) query = orderBy(query);
        if (skip.HasValue) query = query.Skip(skip.Value);
        if (take.HasValue) query = query.Take(take.Value);
        return await query.AsNoTracking().ToListAsync();
    }

    public virtual Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null) query = query.Where(filter);
        return query.CountAsync();
    }

    public virtual Task<bool> AnyAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null) query = query.Where(filter);
        return query.AnyAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _db.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public virtual async Task<IReadOnlyList<T>> SearchAsync(
        Func<IQueryable<T>, IQueryable<T>>? searchFunc,
        Expression<Func<T, bool>>? filter = null,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        // filter
        if (filter != null) query = query.Where(filter);

        // includes
        foreach (var inc in includes) query = query.Include(inc);
        // apply search builder
        if (searchFunc != null) query = searchFunc(query);
        
        return await query.AsNoTracking().ToListAsync();
    }

    public Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return _db.Database.BeginTransactionAsync();
    }
}
