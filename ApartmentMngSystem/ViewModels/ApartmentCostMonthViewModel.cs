using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApartmentMngSystem.ViewModels
{
    public class ApartmentCostMonthViewModel
    {
        public IEnumerable<ApartmentCost> ApartmentCosts;

        public IEnumerable<SelectListItem> Months;
        [ValidateNever]
        public Month SelectedMonth { get; set; }
    }
}
