using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class ProductMap : ProductMapBase
    {
        public ProductMap(EntityTypeBuilder<Product> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Product> type)
        {

        }

    }
}