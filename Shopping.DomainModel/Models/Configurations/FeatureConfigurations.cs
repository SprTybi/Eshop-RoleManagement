using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Models.Configurations
{
  public  class FeatureConfigurations : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.Property(x => x.FeatureName).HasMaxLength(50);
            builder.HasKey(x => x.FeatureID);
            builder.HasMany(x => x.CategoryFeatures).WithOne(x => x.Feature).HasForeignKey(x => x.FeatureID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ProductFeatures).WithOne(x => x.Feature).HasForeignKey(x => x.FeatureID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
