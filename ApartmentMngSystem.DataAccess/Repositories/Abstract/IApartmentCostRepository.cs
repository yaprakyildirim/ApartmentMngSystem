using ApartmentMngSystem.Core.Entities;

namespace ApartmentMngSystem.DataAccess.Repositories.Abstract
{
    public interface IApartmentCostRepository : IGenericRepository<ApartmentCost>
    {
        Task<IEnumerable<ApartmentCost>> GetAllPaidOrderByDescendingAsync();
        Task<IEnumerable<ApartmentCost>> GetAllNotPaidCostsByMonthIncludeApartmentAsync(Month month);
        Task<IEnumerable<ApartmentCost>> GetAllByIsPaidIncludeApartmentAsync(bool isPaid);
        Task<IEnumerable<string>> GetAllEmailsByNotPaidApartmentCostsAsync();
        Task<IEnumerable<ApartmentCost>> GetAllByUserId(string userId);
        Task<ApartmentCost?> GetByIdIncludeAparmentAsync(int id);
    }
}
