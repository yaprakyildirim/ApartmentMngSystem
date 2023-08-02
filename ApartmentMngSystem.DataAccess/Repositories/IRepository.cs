using System.Linq.Expressions;

namespace ApartmentMngSystem.Business.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);

        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);

        Task<T?> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task<int> SaveChangesAsync();

        Task Remove(T entity);

    }
}
