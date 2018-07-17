using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ProductFilterBasicExtension
    {

        public static IQueryable<Product> WithBasicFilters(this IQueryable<Product> queryBase, ProductFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent())
                queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.ProductId));

            if (filters.ProductId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ProductId == filters.ProductId);
			}
            if (filters.Name.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Name.Contains(filters.Name));
			}
            if (filters.Description.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Description.Contains(filters.Description));
			}


            return queryFilter;
        }

		
    }
}