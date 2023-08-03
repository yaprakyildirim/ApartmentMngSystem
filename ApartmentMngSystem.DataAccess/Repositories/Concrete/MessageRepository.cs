using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMngSystem.DataAccess.Repositories.Concrete
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Message>> GetAllByUserIdAndIncludeUserAsync(string userId)
        {
            return await _dbSet.AsNoTracking().Include(x => x.User).Where(x => x.User.Id == userId).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetAllIncludeUser()
        {
            return await _dbSet.AsNoTracking().Include(x => x.User).ToListAsync();
        }

        public async Task<Message?> GetByIdIncludeUser(int id)
        {
            var message = await _dbSet.Where(m => m.Id == id).Include(u => u.User).AsNoTracking().FirstOrDefaultAsync();
            return message;
        }
    }
}
