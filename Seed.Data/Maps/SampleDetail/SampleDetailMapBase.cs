using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class SampleDetailMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<SampleDetail> type);

        public SampleDetailMapBase(EntityTypeBuilder<SampleDetail> type)
        {
            
            type.ToTable("SampleDetail");
            type.Property(t => t.SampleDetailId).HasColumnName("Id");
           

            type.Property(t => t.SampleId).HasColumnName("SampleId");
            type.Property(t => t.Name).HasColumnName("Name").HasColumnType("varchar(50)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(max)");
            type.Property(t => t.Data).HasColumnName("Data");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.SampleDetailId, }); 

			CustomConfig(type);
        }
		
    }
}