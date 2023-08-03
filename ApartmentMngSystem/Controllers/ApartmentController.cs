using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApartmentMngSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ApartmentController : Controller
    {
        [HttpGet]
        public IActionResult AdminEndpoint()
        {

            return Ok("Sadece admin rolündeki kullanıcılar bu endpoint'e erişebilir.");
        }
    }
}
