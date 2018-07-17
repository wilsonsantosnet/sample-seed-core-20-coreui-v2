using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Seed.Application.Interfaces;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using Seed.Dto;
using Common.Domain.Enums;
using Common.API;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Seed.CrossCuting;
using Seed.Domain.Entitys;
using Common.Domain.Base;
using Common.API.Extensions;

namespace Seed.Api.Controllers
{
	[Authorize]
    [Route("api/sampleproduct/more")]
    public class SampleProductMoreController : Controller
    {

        private readonly ISampleProductRepository _rep;
        private readonly ISampleProductApplicationService _app;
		private readonly ILogger _logger;
		private readonly EnviromentInfo _env;

        public SampleProductMoreController(ISampleProductRepository rep, ISampleProductApplicationService app, ILoggerFactory logger, EnviromentInfo env)
        {
            this._rep = rep;
            this._app = app;
			this._logger = logger.CreateLogger<SampleProductMoreController>();
			this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]SampleProductFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger);
            try
            {
                if (filters.FilterBehavior == FilterBehavior.GetDataItem)
                {
                    var searchResult = await this._rep.GetDataItem(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                if (filters.FilterBehavior == FilterBehavior.GetDataCustom)
                {
                    var searchResult = await this._rep.GetDataCustom(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                if (filters.FilterBehavior == FilterBehavior.GetDataListCustom)
                {
                    var searchResult = await this._rep.GetDataListCustom(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

				if (filters.FilterBehavior == FilterBehavior.GetDataListCustomPaging)
                {
                    var paginatedResult = await this._rep.GetDataListCustomPaging(filters);
                    return result.ReturnCustomResponse(paginatedResult.ToSearchResult<dynamic>(), filters);
                }

				
				if (filters.FilterBehavior == FilterBehavior.Export)
                {
					var searchResult = await this._rep.GetDataListCustom(filters);
                    var export = new ExportExcelCustom<dynamic>(filters);
                    var file = export.ExportFile(this.Response, searchResult, "SampleProduct", this._env.RootPath);
                    return File(file, export.ContentTypeExcel(), export.GetFileName());
                }

                throw new InvalidOperationException("invalid FilterBehavior");

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - SampleProduct", filters, new ErrorMapCustom());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<SampleProductDtoSpecialized> dtos)
        {
            var result = new HttpResult<SampleProductDto>(this._logger);
            try
            {
                var returnModels = await this._app.Save(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - SampleProduct", dtos, new ErrorMapCustom());
            }

        }

		[HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<SampleProductDtoSpecialized> dtos)
        {
            var result = new HttpResult<SampleProductDto>(this._logger);
            try
            {
                var returnModels = await this._app.SavePartial(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Seed - SampleProduct", dtos, new ErrorMapCustom());
            }

        }

    }
}
