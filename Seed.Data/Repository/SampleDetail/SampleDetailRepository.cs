using Common.Domain.Base;
using Common.Orm;
using Seed.Data.Context;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using Common.Domain.Model;

namespace Seed.Data.Repository
{
    public class SampleDetailRepository : Repository<SampleDetail>, ISampleDetailRepository
    {
        private CurrentUser _user;
        public SampleDetailRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<SampleDetail> GetBySimplefilters(SampleDetailFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<SampleDetail> GetById(SampleDetailFilter model)
        {
            var _sampledetail = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.SampleDetailId == model.SampleDetailId));

            return _sampledetail;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(SampleDetailFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleDetailId,
				Name = _.Name
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(SampleDetailFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleDetailId,

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(SampleDetailFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleDetailId,
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(SampleDetailFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleDetailId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<SampleDetail> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<SampleDetail> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.SampleDetailId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.SampleDetailId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.SampleDetailId);

            return source;
        }

        protected override IQueryable<SampleDetail> MapperGetByFiltersToDomainFields(IQueryable<SampleDetail> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new SampleDetail
                {

                }).AsQueryable();
            }

            return result.Select(_ => (SampleDetail)_).AsQueryable();

        }

        protected override SampleDetail MapperGetOneToDomainFields(IQueryable<SampleDetail> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new SampleDetail
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<SampleDetail, object>>[] DataAgregation(Expression<Func<SampleDetail, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
