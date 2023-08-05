using ApartmentMngSystem.Business.DTOs;
using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ApartmentMngSystem.ViewModels
{
    public class ApartmentCostPayViewModel
    {
        public PaymentDto PaymentDto { get; set; }

        [ValidateNever]
        public ApartmentCost ApartmentCost { get; set; }

    }
}
