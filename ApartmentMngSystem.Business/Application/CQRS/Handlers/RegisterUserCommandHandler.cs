using ApartmentMngSystem.Core.Application.CQRS.Commands;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using MediatR;

namespace ApartmentMngSystem.Business.Application.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IGenericRepository<User> repository;

        public RegisterUserCommandHandler(IGenericRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            
            await this.repository.CreateAsync(new User
            {
                UserName = request.UserName,

            });
            return Unit.Value;
        }
    }
}
