using Common.Domain.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Domain.Interfaces.Repository
{
    public interface ISampleDetailRepository : IRepository<SampleDetail>
    {
        IQueryable<SampleDetail> GetBySimplefilters(SampleDetailFilter filters);

        Task<SampleDetail> GetById(SampleDetailFilter sampledetail);
		
        Task<IEnumerable<dynamic>> GetDataItem(SampleDetailFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(SampleDetailFilter filters);

		Task<PaginateResult<dynamic>> GetDataListCustomPaging(SampleDetailFilter filters);

        Task<dynamic> GetDataCustom(SampleDetailFilter filters);
    }
}
