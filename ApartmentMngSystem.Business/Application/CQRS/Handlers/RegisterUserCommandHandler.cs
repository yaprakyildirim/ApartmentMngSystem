using ApartmentMngSystem.Core.Application.CQRS.Commands;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ApartmentMngSystem.Business.Application.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdentityNumber = request.IdentityNumber,
                PlateNumber = request.PlateNumber,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return Unit.Value;
            }
            else
            {
                // Hata işleme, örneğin:
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }
        }
    }
}
