using ApartmentMngSystem.Business.DTOs;
using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentMngSystem.Business.Services.Abstract
{
    public interface IApartmentCostService
    {
        Task AddApartmentCost(ApartmentCost apartmentCost);
        Task<IEnumerable<ApartmentCost>> GetAllApartmentCostByMonth(Month month);
        Task<IEnumerable<ApartmentCost>> GetAllApartmentCostsByUser(int userId);
        Task<IEnumerable<ApartmentCost>> GetAllApartmentCostsByPaid(bool isPaid);
        Task<IEnumerable<string>> GetAllEmailByUnpaidApartmentCosts();
        Task<bool> PayApartmentCost(PaymentDto paymentDto, int apartmentCostId);
        Task<ApartmentCost> GetById(int id);
    }
}
