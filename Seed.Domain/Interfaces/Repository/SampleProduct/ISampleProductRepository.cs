using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ISampleProductRepository : IRepository<SampleProduct>
    {
        IQueryable<SampleProduct> GetBySimplefilters(SampleProductFilter filters);

        Task<SampleProduct> GetById(SampleProductFilter sampleproduct);
		
        Task<IEnumerable<dynamic>> GetDataItem(SampleProductFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(SampleProductFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(SampleProductFilter filters);

        Task<dynamic> GetDataCustom(SampleProductFilter filters);
    }
}
