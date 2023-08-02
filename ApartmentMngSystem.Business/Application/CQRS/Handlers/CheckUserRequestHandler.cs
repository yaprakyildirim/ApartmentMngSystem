using ApartmentMngSystem.Business.Repositories;
using ApartmentMngSystem.Core.Application.CQRS.Queries;
using ApartmentMngSystem.Core.Application.Dto;
using ApartmentMngSystem.Core.Entities;
using MediatR;

namespace ApartmentMngSystem.Business.Application.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Role> roleRepository;

        public CheckUserRequestHandler(IRepository<User> userRepository, IRepository<Role> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();

            var user = await this.userRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await this.roleRepository.GetByFilterAsync(x => x.Id == user.RoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
