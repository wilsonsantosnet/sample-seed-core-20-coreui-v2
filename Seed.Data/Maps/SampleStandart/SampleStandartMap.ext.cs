using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class SampleStandartMap : SampleStandartMapBase
    {
        public SampleStandartMap(EntityTypeBuilder<SampleStandart> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<SampleStandart> type)
        {

        }

    }
}