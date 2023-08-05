using ApartmentMngSystem.Business.Services.Abstract;
using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApartmentMngSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAll()
        {
            if (User.IsInRole("Admin"))
            {
                var messages = await _messageService.GetAllMessages();
                await _messageService.UpdateNewMessageStatus();
                return Ok(messages);
            }
            else
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

                if (claim == null)
                {
                    return Unauthorized();
                }

                var messages = await _messageService.GetAllMessagesByUser(claim.Value);
                return Ok(messages);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _messageService.GetById(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _messageService.AddMessage(message);
            return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
        }
    }
}
