using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ApartmentMngSystem.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
        public string? PlateNumber { get; set; }
        [ValidateNever]
        public Apartment? Apartment { get; set; }
        [ValidateNever]
        public ICollection<Message> Message { get; set; }


        public int RoleId { get; set; }

        public Role? Roles { get; set; }
    }
}
