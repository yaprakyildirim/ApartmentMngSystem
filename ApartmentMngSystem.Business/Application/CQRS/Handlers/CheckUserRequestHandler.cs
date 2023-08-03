using ApartmentMngSystem.Core.Application.CQRS.Queries;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using MediatR;

namespace ApartmentMngSystem.Core.TokenOperations.Dto
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Role> roleRepository;

        public CheckUserRequestHandler(IGenericRepository<User> userRepository, IGenericRepository<Role> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            
            
            var user = await this.userRepository.GetByFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);

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
