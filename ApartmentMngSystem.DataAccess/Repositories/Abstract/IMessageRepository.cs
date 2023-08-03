using ApartmentMngSystem.Core.Entities;

namespace ApartmentMngSystem.DataAccess.Repositories.Abstract
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<IEnumerable<Message>> GetAllIncludeUser();
        Task<IEnumerable<Message>> GetAllByUserIdAndIncludeUserAsync(string userId);
        Task<Message?> GetByIdIncludeUser(int id);
    }
}
