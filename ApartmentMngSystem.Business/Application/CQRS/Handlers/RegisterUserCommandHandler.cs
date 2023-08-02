using ApartmentMngSystem.Business.Repositories;
using ApartmentMngSystem.Core.Application.CQRS.Commands;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.Core.Enum;
using MediatR;

namespace ApartmentMngSystem.Business.Application.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<User> repository;

        public RegisterUserCommandHandler(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new User
            {
                Password = request.Password,
                UserName = request.Username,
                RoleId = (int)RoleType.Member,
            });

            return Unit.Value;
        }
    }
}
