using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleProductFilterCustomExtension
    {

        public static IQueryable<SampleProduct> WithCustomFilters(this IQueryable<SampleProduct> queryBase, SampleProductFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<SampleProduct> WithLimitTenant(this IQueryable<SampleProduct> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

