using ApartmentMngSystem.Core.Entities;

namespace ApartmentMngSystem.DataAccess.Repositories.Abstract
{
    public interface IApartmentRepository : IGenericRepository<Apartment>
    {
        Task<IEnumerable<Apartment>> GetAllIncludeUserAsync();
    }
}
