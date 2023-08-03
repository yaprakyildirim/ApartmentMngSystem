using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ApartmentMngSystem.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PlateNumber { get; set; }
        [ValidateNever]
        public Apartment? Apartment { get; set; }
        [ValidateNever]
        public ICollection<Message> Message { get; set; }


        public int RoleId { get; set; }

        public Role? Roles { get; set; }
    }
}
