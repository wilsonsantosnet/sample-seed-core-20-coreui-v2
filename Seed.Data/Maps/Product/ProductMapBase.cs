using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class ProductMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Product> type);

        public ProductMapBase(EntityTypeBuilder<Product> type)
        {
            
            type.ToTable("Product");
            type.Property(t => t.ProductId).HasColumnName("Id");
           

            type.Property(t => t.Name).HasColumnName("Name").HasColumnType("varchar(100)");
            type.Property(t => t.Description).HasColumnName("Description").HasColumnType("varchar(max)");


            type.HasKey(d => new { d.ProductId, }); 

			CustomConfig(type);
        }
		
    }
}