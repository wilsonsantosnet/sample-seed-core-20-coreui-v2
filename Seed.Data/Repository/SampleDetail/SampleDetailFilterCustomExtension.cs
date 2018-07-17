using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleDetailFilterCustomExtension
    {

        public static IQueryable<SampleDetail> WithCustomFilters(this IQueryable<SampleDetail> queryBase, SampleDetailFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<SampleDetail> WithLimitTenant(this IQueryable<SampleDetail> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

