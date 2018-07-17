using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class SampleDetailMap : SampleDetailMapBase
    {
        public SampleDetailMap(EntityTypeBuilder<SampleDetail> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<SampleDetail> type)
        {

        }

    }
}