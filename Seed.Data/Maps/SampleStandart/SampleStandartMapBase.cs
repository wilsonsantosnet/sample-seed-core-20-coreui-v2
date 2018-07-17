using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class SampleStandartMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<SampleStandart> type);

        public SampleStandartMapBase(EntityTypeBuilder<SampleStandart> type)
        {
            
            type.ToTable("SampleStandart");
            type.Property(t => t.SampleStandartId).HasColumnName("SampleStandartId");
           

            type.Property(t => t.Name).HasColumnName("Name").HasColumnType("varchar(200)");


            type.HasKey(d => new { d.SampleStandartId, }); 

			CustomConfig(type);
        }
		
    }
}