using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentMngSystem.Core.Entities
{
    public class Apartment : BaseEntity
    {
        public int ApartmentNumber { get; set; }
        public int BlockNumber { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; } = null!;
        public Status Status { get; set; } = Status.EMPTY;

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        [ValidateNever]
        public User? User { get; set; }
        [ValidateNever]
        public ICollection<ApartmentCost> ApartmentCosts { get; set; }

    }

    public enum Status
    {
        EMPTY,
        FULL
    }
}
