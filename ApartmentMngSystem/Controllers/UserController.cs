using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordGenerator;
using System.Data;

namespace ApartmentMngSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(User user)
        {
            var password = RandomPassword();
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(error => error.Description).ToList());
            }

            await _userManager.AddToRoleAsync(user, "USER");
            return CreatedAtAction(nameof(GetUsers), new { password = password });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, User userView)
        {
            if (id != userView.Id)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(userView.Id);
            if (user == null)
                return NotFound();

            user.FirstName = userView.FirstName;
            user.LastName = userView.LastName;
            user.Email = userView.Email;
            user.IdentityNumber = userView.IdentityNumber;
            user.PlateNumber = userView.PlateNumber;
            user.UserName = userView.UserName;
            user.PhoneNumber = userView.PhoneNumber;

            await _userManager.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userManager.DeleteAsync(user);
            return NoContent();
        }

        private string RandomPassword()
        {
            var pw = new Password();
            return pw.Next();
        }
    }
}
