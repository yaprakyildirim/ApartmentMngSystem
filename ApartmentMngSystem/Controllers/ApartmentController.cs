using ApartmentMngSystem.Business.Services.Abstract;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ApartmentMngSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Roles = "Admin")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        private readonly IUserService _userService;

        public ApartmentController(IApartmentService apartmentService, IUserService userService)
        {
            _apartmentService = apartmentService;
            _userService = userService;
        }
        [ResponseCache(NoStore = true, Duration = 0)]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Apartment>>> Index()
        {
            var apartmentList = await _apartmentService.GetAll();
            return Ok(apartmentList);
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] Apartment apartment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _apartmentService.AddApartment(apartment);
            return CreatedAtAction(nameof(Index), new { id = apartment.Id }, apartment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserApartmentViewModel>> Edit(int id)
        {
            var apartment = await _apartmentService.GetById(id);
            if (apartment == null)
                return NotFound();

            var aparmentUsers = await _userService.GetAllNonResidentUsers();
            var userApartmentViewModel = new UserApartmentViewModel()
            {
                Apartment = apartment,
                AparmentUsers = aparmentUsers.Select(x => new SelectListItem()
                {
                    Text = $"{x.FirstName} {x.LastName}",
                    Value = x.Id.ToString()
                })
            };

            return Ok(userApartmentViewModel);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] UserApartmentViewModel userApartmentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _apartmentService.UpdateApartment(userApartmentViewModel.Apartment);
            return NoContent(); // Başarılı güncelleme için NoContent (204) yanıtı döner.
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var apartment = await _apartmentService.GetById(id);
            if (apartment == null)
                return NotFound();

            await _apartmentService.RemoveApartment(id);
            return NoContent();
        }
    }
}
