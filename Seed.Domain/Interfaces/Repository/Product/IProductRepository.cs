using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> GetBySimplefilters(ProductFilter filters);

        Task<Product> GetById(ProductFilter product);
		
        Task<IEnumerable<dynamic>> GetDataItem(ProductFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(ProductFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(ProductFilter filters);

        Task<dynamic> GetDataCustom(ProductFilter filters);
    }
}
