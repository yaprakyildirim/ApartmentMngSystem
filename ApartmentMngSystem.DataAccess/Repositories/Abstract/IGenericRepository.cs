using System.Linq.Expressions;

namespace ApartmentMngSystem.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class, new()
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
