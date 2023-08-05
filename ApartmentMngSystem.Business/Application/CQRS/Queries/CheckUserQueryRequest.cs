using ApartmentMngSystem.Core.TokenOperations.Dto;
using MediatR;

namespace ApartmentMngSystem.Core.Application.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? IdentityNumber { get; set; } = null!;
        public string? PlateNumber { get; set; } = null!;
    }
}
