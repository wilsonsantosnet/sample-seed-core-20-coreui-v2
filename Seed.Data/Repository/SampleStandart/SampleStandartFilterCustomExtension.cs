using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleStandartFilterCustomExtension
    {

        public static IQueryable<SampleStandart> WithCustomFilters(this IQueryable<SampleStandart> queryBase, SampleStandartFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.AttributeBehavior == "withoutchild")
                queryFilter = queryFilter.Where(_ => _.Sample == null);

            return queryFilter;
        }

		public static IQueryable<SampleStandart> WithLimitTenant(this IQueryable<SampleStandart> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

