using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApartmentMngSystem.ViewModels
{
    public class UserApartmentViewModel
    {
        public Apartment Apartment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AparmentUsers { get; set; }

    }
}
