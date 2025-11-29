using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // Querying
        Task<T?> GetByIdAsync(object id, params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> ListAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes);
        
        // Old Querying
        //Task<List<T>> GetAllAsync();
        //Task<T> GetByIdAsync(int id);


        // Count & exists
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? filter = null);

        // Add / Update / Delete
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);


        // TODO: Delete below if not necessary

        // Search: accept a predicate or a helper that builds predicate from term(s)
        Task<IReadOnlyList<T>> SearchAsync(
            Func<IQueryable<T>, IQueryable<T>>? searchFunc,
            Expression<Func<T, bool>>? filter = null,
            params Expression<Func<T, object>>[] includes);

        // Transactions (simple surface)
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
