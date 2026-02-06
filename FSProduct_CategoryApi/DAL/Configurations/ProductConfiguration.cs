using FSProduct_CategoryApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FSProduct_CategoryApi.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.Desc).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Price)
           .HasColumnType("decimal(18,2)");

     
        }
    }

}
