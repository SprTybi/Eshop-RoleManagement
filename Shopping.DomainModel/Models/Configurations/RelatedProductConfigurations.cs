using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Models.Configurations
{
   public class RelatedProductConfigurations:IEntityTypeConfiguration<RelatedProduct>
    {
        public void Configure(EntityTypeBuilder<RelatedProduct> builder)
        {
            builder.HasIndex(x => new { x.ProductID, x.RelatedToID });
           // builder.HasOne(x => x.Product).WithMany(x => x.RelatedProducts).HasForeignKey(x => x.ProductID);
            //builder.HasOne(x => x.Product).WithMany(x => x.RelatedToProducts).HasForeignKey(x => x.RelatedToID);
        }
    }
}
