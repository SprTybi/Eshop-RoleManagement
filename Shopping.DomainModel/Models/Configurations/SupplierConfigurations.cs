using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Models.Configurations
{
  public  class SupplierConfigurations : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.SupplierID);
            builder.Property(x => x.SupplierName).HasMaxLength(70).IsRequired();
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Supplier).HasForeignKey(x => x.SupplierID).OnDelete(DeleteBehavior.ClientNoAction);

        }
    }
}
