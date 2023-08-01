using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ApartmentMngSystem.Core.Entities
{
    public class ApartmentCost : BaseEntity
    {
        public CostType CostType { get; set; }

        public int Amount { get; set; }

        public bool IsPaid { get; set; }

        public Month Month { get; set; }

        public int ApartmentId { get; set; }
        [ValidateNever]
        public Apartment Apartment { get; set; }
    }
    public enum Month
    {
        JANUARY = 1,
        FEBRUARY = 2,
        MARCH = 3,
        APRIL = 4,
        MAY = 5,
        JUNE = 6,
        JULY = 7,
        AGUST = 8,
        SEPTEMBER = 9,
        OCTOBER = 10,
        NOVEMBER = 11,
        DECEMBER = 12,
    }

    public enum CostType
    {
        ELECTRICITY,
        WATER,
        GAS,
        DUES
    }
}
