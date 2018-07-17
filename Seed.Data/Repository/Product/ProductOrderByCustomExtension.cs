using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ProductOrderCustomExtension
    {

        public static IQueryable<Product> OrderByDomain(this IQueryable<Product> queryBase, ProductFilter filters)
        {
            return queryBase.OrderBy(_ => _.ProductId);
        }

    }
}

