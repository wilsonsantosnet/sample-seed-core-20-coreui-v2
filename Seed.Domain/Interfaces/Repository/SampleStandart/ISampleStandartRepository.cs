using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ISampleStandartRepository : IRepository<SampleStandart>
    {
        IQueryable<SampleStandart> GetBySimplefilters(SampleStandartFilter filters);

        Task<SampleStandart> GetById(SampleStandartFilter samplestandart);
		
        Task<IEnumerable<dynamic>> GetDataItem(SampleStandartFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(SampleStandartFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(SampleStandartFilter filters);

        Task<dynamic> GetDataCustom(SampleStandartFilter filters);
    }
}
