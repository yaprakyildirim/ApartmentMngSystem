using ApartmentMngSystem.Business.DTOs;
using ApartmentMngSystem.Business.Services.Abstract;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using ApartmentMngSystem.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ApartmentMngSystem.Business.Services.Concrete
{
    public class ApartmentCostService : IApartmentCostService
    {
        private readonly CreditCardClientService _creditCardClientService;
        private readonly IApartmentCostRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ApartmentCostService(IApartmentCostRepository repository, IUnitOfWork unitOfWork, CreditCardClientService creditCardClientService)
        {
            _creditCardClientService = creditCardClientService;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddApartmentCost(ApartmentCost apartmentCost)
        {
            await _repository.AddAsync(apartmentCost);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ApartmentCost>> GetAllApartmentCostByMonth(Month month)
        {
            return await _repository.GetAllNotPaidCostsByMonthIncludeApartmentAsync(month);
        }

        public async Task<IEnumerable<ApartmentCost>> GetAllApartmentCostsByPaid(bool isPaid)
        {
            return await _repository.GetAllByIsPaidIncludeApartmentAsync(isPaid);
        }

        public async Task<IEnumerable<ApartmentCost>> GetAllApartmentCostsByUser(string userId)
        {
            return await _repository.GetAllByUserId(userId);
        }

        public async Task<IEnumerable<string>> GetAllEmailByUnpaidApartmentCosts()
        {
            return await _repository.GetAllEmailsByNotPaidApartmentCostsAsync();
        }

        public async Task<bool> PayApartmentCost(PaymentDto paymentDto, int apartmentCostId)
        {
            var paymentResult = await _creditCardClientService.MakePayment(paymentDto);
            var apartmentCost = await GetById(apartmentCostId);
            if (paymentResult)
            {
                apartmentCost.IsPaid = true;
                _repository.Update(apartmentCost);
                await _unitOfWork.CommitAsync();
            }
            return apartmentCost.IsPaid;
        }

        public async Task<ApartmentCost> GetById(int id)
        {
            return await _repository.GetByIdIncludeAparmentAsync(id);
        }
    }
}
