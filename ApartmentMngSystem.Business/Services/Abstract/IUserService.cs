using ApartmentMngSystem.Core.Entities;

namespace ApartmentMngSystem.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<User> GetUserIncludeApartment(string userId);
        Task<IEnumerable<User>> GetAllNonResidentUsers();
    }
}
