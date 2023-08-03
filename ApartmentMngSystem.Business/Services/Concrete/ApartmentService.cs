using ApartmentMngSystem.Business.Services.Abstract;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.Core.Helpers;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using ApartmentMngSystem.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentMngSystem.Business.Services.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ApartmentService(IApartmentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddApartment(Apartment apartment)
        {
            await _repository.AddAsync(apartment);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveApartment(int id)
        {
            var deletedApartment = await _repository.GetByIdAsync(id);
            if (deletedApartment != null)
            {
                _repository.Remove(deletedApartment);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<Apartment>> GetAll()
        {
            return await _repository.GetAllIncludeUserAsync();
        }

        public async Task UpdateApartment(Apartment apartment)
        {
            if (apartment.UserId != null)
                apartment.Status = Status.FULL;
            else
                apartment.Status = Status.EMPTY;

            _repository.Update(apartment);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Apartment> GetById(int id)
        {
            var apartment = await _repository.GetByIdAsync(id);
            if (apartment == null)
                throw new NotFoundException("Apartment dairesi bulunamadı!");
            return apartment;
        }
    }
}
