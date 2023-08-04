using ApartmentMngSystem.Core.Application.CQRS.Queries;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using MediatR;

namespace ApartmentMngSystem.Core.TokenOperations.Dto
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IGenericRepository<User> userRepository;

        public CheckUserRequestHandler(IGenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            
            
            var user = await this.userRepository.GetByFilterAsync(x => x.UserName == request.UserName);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
            }
            return dto;
        }
    }
}
