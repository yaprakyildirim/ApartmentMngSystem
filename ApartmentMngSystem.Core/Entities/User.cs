using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace ApartmentMngSystem.Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string? PlateNumber { get; set; }
        [ValidateNever]

        [JsonIgnore]
        public Apartment Apartment { get; set; }
        [ValidateNever]
        public ICollection<Message> Message { get; set; }
    }
}
