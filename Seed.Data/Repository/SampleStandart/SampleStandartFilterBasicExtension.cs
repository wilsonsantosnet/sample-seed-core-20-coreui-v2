using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class SampleStandartFilterBasicExtension
    {

        public static IQueryable<SampleStandart> WithBasicFilters(this IQueryable<SampleStandart> queryBase, SampleStandartFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent())
                queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.SampleStandartId));

            if (filters.SampleStandartId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SampleStandartId == filters.SampleStandartId);
			}
            if (filters.Name.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Name.Contains(filters.Name));
			}


            return queryFilter;
        }

		
    }
}