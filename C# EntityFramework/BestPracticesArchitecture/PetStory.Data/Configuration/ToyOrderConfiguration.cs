namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> toyOrder)
        {
            toyOrder.HasKey(fo => new { fo.OrderId, fo.ToyId });

            toyOrder.HasOne(fo => fo.Toy)
                     .WithMany(fo => fo.Orders)
                     .HasForeignKey(fo => fo.ToyId)
                     .OnDelete(DeleteBehavior.Restrict);

            toyOrder.HasOne(fo => fo.Order)
                    .WithMany(fo => fo.Toys)
                    .HasForeignKey(fo => fo.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
