using System.Linq.Expressions;

namespace ApartmentMngSystem.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T?> CreateAsync(T entity);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
