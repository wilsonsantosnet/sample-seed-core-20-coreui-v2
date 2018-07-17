using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Seed.Application.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Services;
using Seed.Dto;
using System.Threading.Tasks;
using Common.Domain.Model;
using System.Collections.Generic;

namespace Seed.Application
{
    public class SampleDetailApplicationServiceBase : ApplicationServiceBase<SampleDetail, SampleDetailDto, SampleDetailFilter>, ISampleDetailApplicationService
    {
        protected readonly ValidatorAnnotations<SampleDetailDto> _validatorAnnotations;
        protected readonly ISampleDetailService _service;
		protected readonly CurrentUser _user;

        public SampleDetailApplicationServiceBase(ISampleDetailService service, IUnitOfWork uow, ICache cache, CurrentUser user) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("SampleDetail");
            this._validatorAnnotations = new ValidatorAnnotations<SampleDetailDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<SampleDetail> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as SampleDetailDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<SampleDetail>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<SampleDetail>();
			foreach (var dto in dtos)
			{
				var _dto = dto as SampleDetailDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<SampleDetail> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as SampleDetailDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
