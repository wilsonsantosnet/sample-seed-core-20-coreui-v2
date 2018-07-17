using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seed.Domain.Services
{
    public class SampleProductServiceBase : ServiceBase<SampleProduct>
    {
        protected readonly ISampleProductRepository _rep;

        public SampleProductServiceBase(ISampleProductRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<SampleProduct> GetOne(SampleProductFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<SampleProduct>> GetByFilters(SampleProductFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<SampleProduct>> GetByFiltersPaging(SampleProductFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(SampleProduct sampleproduct)
        {
            this._rep.Remove(sampleproduct);
        }

        public virtual Summary GetSummary(PaginateResult<SampleProduct> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
				PageSize = paginateResult.PageSize,
            };
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return this._validationResult;
        }

        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return this._validationConfirm;
        }

        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return this._validationWarning;
        }

        public override async Task<SampleProduct> Save(SampleProduct sampleproduct, bool questionToContinue = false)
        {
			var sampleproductOld = await this.GetOne(new SampleProductFilter { SampleId = sampleproduct.SampleId, ProductId = sampleproduct.ProductId });
			var sampleproductOrchestrated = await this.DomainOrchestration(sampleproduct, sampleproductOld);

            if (questionToContinue)
            {
                if (this.Continue(sampleproductOrchestrated, sampleproductOld) == false)
                    return sampleproductOrchestrated;
            }

            return this.SaveWithValidation(sampleproductOrchestrated, sampleproductOld);
        }

        public override async Task<SampleProduct> SavePartial(SampleProduct sampleproduct, bool questionToContinue = false)
        {
            var sampleproductOld = await this.GetOne(new SampleProductFilter { SampleId = sampleproduct.SampleId, ProductId = sampleproduct.ProductId });
			var sampleproductOrchestrated = await this.DomainOrchestration(sampleproduct, sampleproductOld);

            if (questionToContinue)
            {
                if (this.Continue(sampleproductOrchestrated, sampleproductOld) == false)
                    return sampleproductOrchestrated;
            }

            return SaveWithOutValidation(sampleproductOrchestrated, sampleproductOld);
        }

        protected override SampleProduct SaveWithOutValidation(SampleProduct sampleproduct, SampleProduct sampleproductOld)
        {
            sampleproduct = this.SaveDefault(sampleproduct, sampleproductOld);
			this._cacheHelper.ClearCache();

			this._validationResult = sampleproduct.GetDomainValidation();
			this._validationWarning = sampleproduct.GetDomainWarning();
			if (!sampleproduct.IsValid())
                return sampleproduct;

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return sampleproduct;
        }

		protected override SampleProduct SaveWithValidation(SampleProduct sampleproduct, SampleProduct sampleproductOld)
        {
            if (!this.DataAnnotationIsValid())
                return sampleproduct;

			this._validationResult = sampleproduct.GetDomainValidation();
			this._validationWarning = sampleproduct.GetDomainWarning();
			if (!sampleproduct.IsValid())
				return sampleproduct;

            this.Specifications(sampleproduct);

            if (!this._validationResult.IsValid)
                return sampleproduct;
            
            sampleproduct = this.SaveDefault(sampleproduct, sampleproductOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return sampleproduct;
        }

		protected virtual void Specifications(SampleProduct sampleproduct)
        {
            this._validationResult  = this._validationResult.Merge(new SampleProductIsSuitableValidation(this._rep).Validate(sampleproduct));
			this._validationWarning  = this._validationWarning.Merge(new SampleProductIsSuitableWarning(this._rep).Validate(sampleproduct));
        }

        protected virtual SampleProduct SaveDefault(SampleProduct sampleproduct, SampleProduct sampleproductOld)
        {
			

            var isNew = sampleproductOld.IsNull();			
            if (isNew)
                sampleproduct = this.AddDefault(sampleproduct);
            else
				sampleproduct = this.UpdateDefault(sampleproduct);

            return sampleproduct;
        }
		
        protected virtual SampleProduct AddDefault(SampleProduct sampleproduct)
        {
            sampleproduct = this._rep.Add(sampleproduct);
            return sampleproduct;
        }

		protected virtual SampleProduct UpdateDefault(SampleProduct sampleproduct)
        {
            sampleproduct = this._rep.Update(sampleproduct);
            return sampleproduct;
        }
				
		public virtual async Task<SampleProduct> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SampleProduct.SampleProductFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<SampleProduct> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SampleProduct.SampleProductFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
