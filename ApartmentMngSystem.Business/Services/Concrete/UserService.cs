using ApartmentMngSystem.Business.Services.Abstract;
using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMngSystem.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;


        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserIncludeApartment(int userId)
        {
            var user = await _userManager.Users.Where(u => u.Id == userId).Include(u => u.Apartment).FirstOrDefaultAsync();
            return user;
        }


        public async Task<IEnumerable<User>> GetAllNonResidentUsers()
        {
            return await _userManager.Users.Where(x => x.Apartment == null).ToListAsync();
        }
    }
}
