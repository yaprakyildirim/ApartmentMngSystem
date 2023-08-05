using ApartmentMngSystem.Business.Services.Abstract;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ApartmentMngSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ApartmentCostController : ControllerBase
    {
        private readonly IApartmentCostService _apartmentCostService;
        private readonly IApartmentService _apartmentService;

        public ApartmentCostController(IApartmentCostService apartmentCostService, IApartmentService apartmentService)
        {
            _apartmentCostService = apartmentCostService;
            _apartmentService = apartmentService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCostsByMonthOrUser()
        {
            var month = Month.OCTOBER;
            var apartmentCosts = new object();

            if (User.IsInRole("Admin"))
            {
                apartmentCosts = await _apartmentCostService.GetAllApartmentCostByMonth(month);
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                apartmentCosts = await _apartmentCostService.GetAllApartmentCostsByUser(claim.Value);
            }

            var aparmentCostMonthView = new ApartmentCostMonthViewModel()
            {
                ApartmentCosts = (IEnumerable<ApartmentCost>)apartmentCosts,
                Months = GetMonths(),
                SelectedMonth = month
            };

            return Ok(aparmentCostMonthView);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("create")]
        public async Task<IActionResult> GetCreateData()
        {
            var aparments = await _apartmentService.GetAll();

            var apartmentCostViewModel = new ApartmentCostViewModel()
            {
                Apartments = aparments.Select(a => new SelectListItem()
                {
                    Text = "Blok No: " + a.BlockNumber.ToString() + "Daire No: " + a.ApartmentNumber.ToString(),
                    Value = a.Id.ToString()
                }),
                Types = GetCostTypes(),
                Months = GetMonths()
            };

            return Ok(apartmentCostViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(ApartmentCostViewModel apartmentCostViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apartmentCostService.AddApartmentCost(apartmentCostViewModel.ApartmentCost);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "User")]
        [HttpGet("pay/{id}")]
        public async Task<IActionResult> GetPaymentDetails(int id)
        {
            var apartmentCost = await _apartmentCostService.GetById(id);
            var apartmentCostPayViewModel = new ApartmentCostPayViewModel()
            {
                ApartmentCost = apartmentCost
            };
            return Ok(apartmentCostPayViewModel);
        }

        [Authorize(Roles = "User")]
        [HttpPost("pay/{id}")]
        public async Task<IActionResult> Pay(int id, ApartmentCostPayViewModel apartmentCostPayViewModel)
        {
            if (ModelState.IsValid)
            {
                apartmentCostPayViewModel.PaymentDto.PaidAmount = apartmentCostPayViewModel.ApartmentCost.Amount;
                var result = await _apartmentCostService.PayApartmentCost(apartmentCostPayViewModel.PaymentDto, apartmentCostPayViewModel.ApartmentCost.Id);

                if (result)
                    return Ok();
                else
                    return BadRequest("Ödeme yapılamadı");
            }
            return BadRequest(ModelState);
        }

        private IEnumerable<SelectListItem> GetMonths()
        {
            return Enum.GetValues(typeof(Month))
                                .Cast<Month>()
                                .ToList().Select(x => new SelectListItem()
                                {
                                    Text = x.ToString(),
                                    Value = ((int)x).ToString()
                                });
        }

        private IEnumerable<SelectListItem> GetCostTypes()
        {
            return Enum.GetValues(typeof(CostType))
                                .Cast<CostType>()
                                .ToList().Select(x => new SelectListItem()
                                {
                                    Text = x.ToString(),
                                    Value = ((int)x).ToString()
                                });
        }
    }
}
