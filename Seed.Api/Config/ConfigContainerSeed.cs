using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Microsoft.Extensions.DependencyInjection;
using Seed.Application;
using Seed.Application.Interfaces;
using Seed.Data.Context;
using Seed.Data.Repository;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Interfaces.Services;
using Seed.Domain.Services;

namespace Seed.Api
{
    public static partial class ConfigContainerSeed
    {

        public static void Config(IServiceCollection services)
        {
            services.AddScoped<ICache, RedisComponent>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextSeed>>();
            
			services.AddScoped<ISampleStandartApplicationService, SampleStandartApplicationService>();
			services.AddScoped<ISampleStandartService, SampleStandartService>();
			services.AddScoped<ISampleStandartRepository, SampleStandartRepository>();

			services.AddScoped<ISampleApplicationService, SampleApplicationService>();
			services.AddScoped<ISampleService, SampleService>();
			services.AddScoped<ISampleRepository, SampleRepository>();

			services.AddScoped<ISampleDetailApplicationService, SampleDetailApplicationService>();
			services.AddScoped<ISampleDetailService, SampleDetailService>();
			services.AddScoped<ISampleDetailRepository, SampleDetailRepository>();

			services.AddScoped<ISampleTypeApplicationService, SampleTypeApplicationService>();
			services.AddScoped<ISampleTypeService, SampleTypeService>();
			services.AddScoped<ISampleTypeRepository, SampleTypeRepository>();

			services.AddScoped<IProductApplicationService, ProductApplicationService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductRepository, ProductRepository>();

			services.AddScoped<ISampleProductApplicationService, SampleProductApplicationService>();
			services.AddScoped<ISampleProductService, SampleProductService>();
			services.AddScoped<ISampleProductRepository, SampleProductRepository>();



            RegisterOtherComponents(services);
        }
    }
}
