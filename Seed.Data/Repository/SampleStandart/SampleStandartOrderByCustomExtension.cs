using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleStandartOrderCustomExtension
    {

        public static IQueryable<SampleStandart> OrderByDomain(this IQueryable<SampleStandart> queryBase, SampleStandartFilter filters)
        {
            return queryBase.OrderBy(_ => _.SampleStandartId);
        }

    }
}

