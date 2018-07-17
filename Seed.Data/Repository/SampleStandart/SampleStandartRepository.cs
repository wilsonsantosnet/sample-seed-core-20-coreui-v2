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
    public class SampleStandartRepository : Repository<SampleStandart>, ISampleStandartRepository
    {
        private CurrentUser _user;
        public SampleStandartRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<SampleStandart> GetBySimplefilters(SampleStandartFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<SampleStandart> GetById(SampleStandartFilter model)
        {
            var _samplestandart = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.SampleStandartId == model.SampleStandartId));

            return _samplestandart;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(SampleStandartFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleStandartId,
				Name = _.Name
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(SampleStandartFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleStandartId,

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(SampleStandartFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleStandartId,
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(SampleStandartFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleStandartId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<SampleStandart> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<SampleStandart> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.SampleStandartId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.SampleStandartId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.SampleStandartId);

            return source;
        }

        protected override IQueryable<SampleStandart> MapperGetByFiltersToDomainFields(IQueryable<SampleStandart> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new SampleStandart
                {

                }).AsQueryable();
            }

            return result.Select(_ => (SampleStandart)_).AsQueryable();

        }

        protected override SampleStandart MapperGetOneToDomainFields(IQueryable<SampleStandart> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new SampleStandart
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<SampleStandart, object>>[] DataAgregation(Expression<Func<SampleStandart, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
