using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleDetailOrderCustomExtension
    {

        public static IQueryable<SampleDetail> OrderByDomain(this IQueryable<SampleDetail> queryBase, SampleDetailFilter filters)
        {
            return queryBase.OrderBy(_ => _.SampleDetailId);
        }

    }
}

