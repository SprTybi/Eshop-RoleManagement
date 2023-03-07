using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Models.Configurations
{
   public class OrderConfigurations: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderID);
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderID)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
