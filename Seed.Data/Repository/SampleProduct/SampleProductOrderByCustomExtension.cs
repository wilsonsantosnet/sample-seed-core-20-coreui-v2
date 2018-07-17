using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleProductOrderCustomExtension
    {

        public static IQueryable<SampleProduct> OrderByDomain(this IQueryable<SampleProduct> queryBase, SampleProductFilter filters)
        {
            return queryBase.OrderBy(_ => _.SampleId).ThenBy(_ => _.ProductId);
        }

    }
}

