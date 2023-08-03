using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMngSystem.DataAccess.Repositories.Concrete
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Apartment>> GetAllIncludeUserAsync()
        {
            return await _dbSet.AsNoTracking().Include(x => x.User).ToListAsync();
        }
    }
}
