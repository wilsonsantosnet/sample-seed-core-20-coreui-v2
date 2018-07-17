using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class SampleProductMap : SampleProductMapBase
    {
        public SampleProductMap(EntityTypeBuilder<SampleProduct> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<SampleProduct> type)
        {

        }

    }
}