using Microsoft.AspNetCore.Identity;

namespace ApartmentMngSystem.Core.Entities
{
    public class Role : IdentityRole<int>
    {
        public int Id { get; set; }
        public string? Definition { get; set; }

        public List<User>? Users { get; set; }
    }
}
