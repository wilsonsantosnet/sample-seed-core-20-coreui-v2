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
    public class SampleStandartServiceBase : ServiceBase<SampleStandart>
    {
        protected readonly ISampleStandartRepository _rep;

        public SampleStandartServiceBase(ISampleStandartRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<SampleStandart> GetOne(SampleStandartFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<SampleStandart>> GetByFilters(SampleStandartFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<SampleStandart>> GetByFiltersPaging(SampleStandartFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(SampleStandart samplestandart)
        {
            this._rep.Remove(samplestandart);
        }

        public virtual Summary GetSummary(PaginateResult<SampleStandart> paginateResult)
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

        public override async Task<SampleStandart> Save(SampleStandart samplestandart, bool questionToContinue = false)
        {
			var samplestandartOld = await this.GetOne(new SampleStandartFilter { SampleStandartId = samplestandart.SampleStandartId });
			var samplestandartOrchestrated = await this.DomainOrchestration(samplestandart, samplestandartOld);

            if (questionToContinue)
            {
                if (this.Continue(samplestandartOrchestrated, samplestandartOld) == false)
                    return samplestandartOrchestrated;
            }

            return this.SaveWithValidation(samplestandartOrchestrated, samplestandartOld);
        }

        public override async Task<SampleStandart> SavePartial(SampleStandart samplestandart, bool questionToContinue = false)
        {
            var samplestandartOld = await this.GetOne(new SampleStandartFilter { SampleStandartId = samplestandart.SampleStandartId });
			var samplestandartOrchestrated = await this.DomainOrchestration(samplestandart, samplestandartOld);

            if (questionToContinue)
            {
                if (this.Continue(samplestandartOrchestrated, samplestandartOld) == false)
                    return samplestandartOrchestrated;
            }

            return SaveWithOutValidation(samplestandartOrchestrated, samplestandartOld);
        }

        protected override SampleStandart SaveWithOutValidation(SampleStandart samplestandart, SampleStandart samplestandartOld)
        {
            samplestandart = this.SaveDefault(samplestandart, samplestandartOld);
			this._cacheHelper.ClearCache();

			this._validationResult = samplestandart.GetDomainValidation();
			this._validationWarning = samplestandart.GetDomainWarning();
			if (!samplestandart.IsValid())
                return samplestandart;

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return samplestandart;
        }

		protected override SampleStandart SaveWithValidation(SampleStandart samplestandart, SampleStandart samplestandartOld)
        {
            if (!this.DataAnnotationIsValid())
                return samplestandart;

			this._validationResult = samplestandart.GetDomainValidation();
			this._validationWarning = samplestandart.GetDomainWarning();
			if (!samplestandart.IsValid())
				return samplestandart;

            this.Specifications(samplestandart);

            if (!this._validationResult.IsValid)
                return samplestandart;
            
            samplestandart = this.SaveDefault(samplestandart, samplestandartOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return samplestandart;
        }

		protected virtual void Specifications(SampleStandart samplestandart)
        {
            this._validationResult  = this._validationResult.Merge(new SampleStandartIsSuitableValidation(this._rep).Validate(samplestandart));
			this._validationWarning  = this._validationWarning.Merge(new SampleStandartIsSuitableWarning(this._rep).Validate(samplestandart));
        }

        protected virtual SampleStandart SaveDefault(SampleStandart samplestandart, SampleStandart samplestandartOld)
        {
			

            var isNew = samplestandartOld.IsNull();			
            if (isNew)
                samplestandart = this.AddDefault(samplestandart);
            else
				samplestandart = this.UpdateDefault(samplestandart);

            return samplestandart;
        }
		
        protected virtual SampleStandart AddDefault(SampleStandart samplestandart)
        {
            samplestandart = this._rep.Add(samplestandart);
            return samplestandart;
        }

		protected virtual SampleStandart UpdateDefault(SampleStandart samplestandart)
        {
            samplestandart = this._rep.Update(samplestandart);
            return samplestandart;
        }
				
		public virtual async Task<SampleStandart> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SampleStandart.SampleStandartFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<SampleStandart> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new SampleStandart.SampleStandartFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
