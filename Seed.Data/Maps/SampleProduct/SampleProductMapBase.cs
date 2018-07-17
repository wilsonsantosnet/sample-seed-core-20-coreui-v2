using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class SampleProductMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<SampleProduct> type);

        public SampleProductMapBase(EntityTypeBuilder<SampleProduct> type)
        {
            
            type.ToTable("SampleProduct");
            type.Property(t => t.SampleId).HasColumnName("SampleId");
            type.Property(t => t.ProductId).HasColumnName("ProductId");
           



            type.HasKey(d => new { d.SampleId,d.ProductId, }); 

			CustomConfig(type);
        }
		
    }
}