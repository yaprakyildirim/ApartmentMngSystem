using MediatR;

namespace ApartmentMngSystem.Core.Application.CQRS.Commands
{
    public class RegisterUserCommandRequest : IRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PlateNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
