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
    public class SampleProductRepository : Repository<SampleProduct>, ISampleProductRepository
    {
        private CurrentUser _user;
        public SampleProductRepository(DbContextSeed ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<SampleProduct> GetBySimplefilters(SampleProductFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<SampleProduct> GetById(SampleProductFilter model)
        {
            var _sampleproduct = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.SampleId == model.SampleId).Where(_=>_.ProductId == model.ProductId));

            return _sampleproduct;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(SampleProductFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleId,
				Name = _.SampleId
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(SampleProductFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleId,

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(SampleProductFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleId,
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(SampleProductFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SampleId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<SampleProduct> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<SampleProduct> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.SampleProductId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.SampleProductId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.SampleProductId);

            return source;
        }

        protected override IQueryable<SampleProduct> MapperGetByFiltersToDomainFields(IQueryable<SampleProduct> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new SampleProduct
                {

                }).AsQueryable();
            }

            return result.Select(_ => (SampleProduct)_).AsQueryable();

        }

        protected override SampleProduct MapperGetOneToDomainFields(IQueryable<SampleProduct> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new SampleProduct
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<SampleProduct, object>>[] DataAgregation(Expression<Func<SampleProduct, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
