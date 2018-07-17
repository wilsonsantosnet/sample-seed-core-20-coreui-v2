using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleProductFilterBasicExtension
    {

        public static IQueryable<SampleProduct> WithBasicFilters(this IQueryable<SampleProduct> queryBase, SampleProductFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent())
                queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.SampleId));

            if (filters.SampleId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SampleId == filters.SampleId);
			}
            if (filters.ProductId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ProductId == filters.ProductId);
			}


            return queryFilter;
        }

		
    }
}