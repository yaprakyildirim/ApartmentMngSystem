using ApartmentMngSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMngSystem.DataAccess.DataSeed
{
    internal class ApartmentCostSeed : IEntityTypeConfiguration<ApartmentCost>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApartmentCost> builder)
        {
            builder.HasData(new ApartmentCost
            {
                Id = 1,
                ApartmentId = 1,
                Month = Month.DECEMBER,
                IsPaid = false,
                Amount = 180,
                CostType = CostType.ELECTRICITY

            },
                            new ApartmentCost
                            {
                                Id = 2,
                                ApartmentId = 1,
                                Month = Month.DECEMBER,
                                IsPaid = false,
                                Amount = 240,
                                CostType = CostType.WATER

                            },
                            new ApartmentCost
                            {
                                Id = 3,
                                ApartmentId = 1,
                                Month = Month.DECEMBER,
                                IsPaid = false,
                                Amount = 850,
                                CostType = CostType.GAS

                            },
                            new ApartmentCost
                            {
                                Id = 4,
                                ApartmentId = 2,
                                Month = Month.SEPTEMBER,
                                IsPaid = false,
                                Amount = 352,
                                CostType = CostType.ELECTRICITY

                            },
                            new ApartmentCost
                            {
                                Id = 5,
                                ApartmentId = 2,
                                Month = Month.OCTOBER,
                                IsPaid = false,
                                Amount = 550,
                                CostType = CostType.GAS
                            },
                            new ApartmentCost
                            {
                                Id = 6,
                                ApartmentId = 2,
                                Month = Month.SEPTEMBER,
                                IsPaid = true,
                                Amount = 690,
                                CostType = CostType.GAS
                            },
                            new ApartmentCost
                            {
                                Id = 7,
                                ApartmentId = 3,
                                Month = Month.SEPTEMBER,
                                IsPaid = true,
                                Amount = 880,
                                CostType = CostType.GAS
                            },
                            new ApartmentCost
                            {
                                Id = 8,
                                ApartmentId = 3,
                                Month = Month.SEPTEMBER,
                                IsPaid = true,
                                Amount = 490,
                                CostType = CostType.GAS
                            },
                            new ApartmentCost
                            {
                                Id = 9,
                                ApartmentId = 4,
                                Month = Month.OCTOBER,
                                IsPaid = true,
                                Amount = 247,
                                CostType = CostType.ELECTRICITY
                            },
                            new ApartmentCost
                            {
                                Id = 10,
                                ApartmentId = 4,
                                Month = Month.OCTOBER,
                                IsPaid = true,
                                Amount = 80,
                                CostType = CostType.WATER
                            },
                            new ApartmentCost
                            {
                                Id = 11,
                                ApartmentId = 1,
                                Month = Month.DECEMBER,
                                IsPaid = true,
                                Amount = 89,
                                CostType = CostType.WATER
                            },
                            new ApartmentCost
                            {
                                Id = 12,
                                ApartmentId = 1,
                                Month = Month.DECEMBER,
                                IsPaid = true,
                                Amount = 567,
                                CostType = CostType.GAS
                            },
                            new ApartmentCost
                            {
                                Id = 13,
                                ApartmentId = 1,
                                Month = Month.SEPTEMBER,
                                IsPaid = true,
                                Amount = 135,
                                CostType = CostType.ELECTRICITY
                            });
        }
    }
}
