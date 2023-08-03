using ApartmentMngSystem.Core.Entities;

namespace ApartmentMngSystem.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<User> GetUserIncludeApartment(int userId);
        Task<IEnumerable<User>> GetAllNonResidentUsers();
    }
}
