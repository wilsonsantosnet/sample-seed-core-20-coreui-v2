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
    public class SampleDetailServiceBase : ServiceBase<SampleDetail>
    {
        protected readonly ISampleDetailRepository _rep;

        public SampleDetailServiceBase(ISampleDetailRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<SampleDetail> GetOne(SampleDetailFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<SampleDetail>> GetByFilters(SampleDetailFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<SampleDetail>> GetByFiltersPaging(SampleDetailFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(SampleDetail sampledetail)
        {
            this._rep.Remove(sampledetail);
        }

        public virtual Summary GetSummary(PaginateResult<SampleDetail> paginateResult)
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

        public override async Task<SampleDetail> Save(SampleDetail sampledetail, bool questionToContinue = false)
        {
			var sampledetailOld = await this.GetOne(new SampleDetailFilter { SampleDetailId = sampledetail.SampleDetailId });
			var sampledetailOrchestrated = await this.DomainOrchestration(sampledetail, sampledetailOld);

            if (questionToContinue)
            {
                if (this.Continue(sampledetailOrchestrated, sampledetailOld) == false)
                    return sampledetailOrchestrated;
            }

            return this.SaveWithValidation(sampledetailOrchestrated, sampledetailOld);
        }

        public override async Task<SampleDetail> SavePartial(SampleDetail sampledetail, bool questionToContinue = false)
        {
            var sampledetailOld = await this.GetOne(new SampleDetailFilter { SampleDetailId = sampledetail.SampleDetailId });
			var sampledetailOrchestrated = await this.DomainOrchestration(sampledetail, sampledetailOld);

            if (questionToContinue)
            {
                if (this.Continue(sampledetailOrchestrated, sampledetailOld) == false)
                    return sampledetailOrchestrated;
            }

            return SaveWithOutValidation(sampledetailOrchestrated, sampledetailOld);
        }

        protected override SampleDetail SaveWithOutValidation(SampleDetail sampledetail, SampleDetail sampledetailOld)
        {
            sampledetail = this.SaveDefault(sampledetail, sampledetailOld);
			this._cacheHelper.ClearCache();

			this._validationResult = sampledetail.GetDomainValidation();
			this._validationWarning = sampledetail.GetDomainWarning();
			if (!sampledetail.IsValid())
                return sampledetail;

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return sampledetail;
        }

		protected override SampleDetail SaveWithValidation(SampleDetail sampledetail, SampleDetail sampledetailOld)
        {
            if (!this.DataAnnotationIsValid())
                return sampledetail;

			this._validationResult = sampledetail.GetDomainValidation();
			this._validationWarning = sampledetail.GetDomainWarning();
			if (!sampledetail.IsValid())
				return sampledetail;

            this.Specifications(sampledetail);

            if (!this._validationResult.IsValid)
                return sampledetail;
            
            sampledetail = this.SaveDefault(sampledetail, sampledetailOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return sampledetail;
        }

		protected virtual void Specifications(SampleDetail sampledetail)
        {
            this._validationResult  = this._validationResult.Merge(new SampleDetailIsSuitableValidation(this._rep).Validate(sampledetail));
			this._validationWarning  = this._validationWarning.Merge(new SampleDetailIsSuitableWarning(this._rep).Validate(sampledetail));
        }

        protected virtual SampleDetail SaveDefault(SampleDetail sampledetail, SampleDetail sampledetailOld)
        {
			sampledetail = this.AuditDefault(sampledetail, sampledetailOld);

            var isNew = sampledetailOld.IsNull();			
            if (isNew)
                sampledetail = this.AddDefault(sampledetail);
            else
				sampledetail = this.UpdateDefault(sampledetail);

            return sampledetail;
        }
		
        protected virtual SampleDetail AddDefault(SampleDetail sampledetail)
        {
            sampledetail = this._rep.Add(sampledetail);
            return sampledetail;
        }

		protected virtual SampleDetail UpdateDefault(SampleDetail sampledetail)
        {
            sampledetail = this._rep.Update(sampledetail);
            return sampledetail;
        }
				
		public virtual async Task<SampleDetail> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SampleDetail.SampleDetailFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<SampleDetail> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SampleDetail.SampleDetailFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
