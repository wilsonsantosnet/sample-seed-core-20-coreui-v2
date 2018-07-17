using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Seed.Application.Interfaces;
using Seed.Domain.Filter;
using Seed.Dto;
using Common.API;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Seed.CrossCuting;

namespace Seed.Api.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductApplicationService _app;
		private readonly ILogger _logger;
		private readonly IHostingEnvironment _env;
      
        public ProductController(IProductApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
        {
            this._app = app;
			this._logger = logger.CreateLogger<ProductController>();
			this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ProductFilter filters)
        {
            var result = new HttpResult<ProductDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Product", filters, new ErrorMapCustom());
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]ProductFilter filters)
		{
			var result = new HttpResult<ProductDto>(this._logger);
            try
            {
				if (id.IsSent()) filters.ProductId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Product", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductDtoSpecialized dto)
        {
            var result = new HttpResult<ProductDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Product", dto, new ErrorMapCustom());
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ProductDtoSpecialized dto)
        {
            var result = new HttpResult<ProductDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Product", dto, new ErrorMapCustom());
            }
        }


        [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, ProductDto dto)
        {
            var result = new HttpResult<ProductDto>(this._logger);
            try
            {
				if (id.IsSent()) dto.ProductId = id;
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Product", dto, new ErrorMapCustom());
            }
        }



    }
}
