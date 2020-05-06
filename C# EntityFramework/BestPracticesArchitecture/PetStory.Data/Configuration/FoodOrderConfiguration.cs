
namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> foodOrder)
        {
            foodOrder.HasKey(fo => new { fo.OrderId, fo.FoodId });

            foodOrder.HasOne(fo => fo.Food)
                     .WithMany(fo => fo.Orders)
                     .HasForeignKey(fo => fo.FoodId)
                     .OnDelete(DeleteBehavior.Restrict);

            foodOrder.HasOne(fo => fo.Order)
                    .WithMany(fo => fo.Food)
                    .HasForeignKey(fo => fo.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
