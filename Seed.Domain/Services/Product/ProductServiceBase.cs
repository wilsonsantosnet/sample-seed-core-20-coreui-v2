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
    public class ProductServiceBase : ServiceBase<Product>
    {
        protected readonly IProductRepository _rep;

        public ProductServiceBase(IProductRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Product> GetOne(ProductFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Product>> GetByFilters(ProductFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Product>> GetByFiltersPaging(ProductFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Product product)
        {
            this._rep.Remove(product);
        }

        public virtual Summary GetSummary(PaginateResult<Product> paginateResult)
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

        public override async Task<Product> Save(Product product, bool questionToContinue = false)
        {
			var productOld = await this.GetOne(new ProductFilter { ProductId = product.ProductId });
			var productOrchestrated = await this.DomainOrchestration(product, productOld);

            if (questionToContinue)
            {
                if (this.Continue(productOrchestrated, productOld) == false)
                    return productOrchestrated;
            }

            return this.SaveWithValidation(productOrchestrated, productOld);
        }

        public override async Task<Product> SavePartial(Product product, bool questionToContinue = false)
        {
            var productOld = await this.GetOne(new ProductFilter { ProductId = product.ProductId });
			var productOrchestrated = await this.DomainOrchestration(product, productOld);

            if (questionToContinue)
            {
                if (this.Continue(productOrchestrated, productOld) == false)
                    return productOrchestrated;
            }

            return SaveWithOutValidation(productOrchestrated, productOld);
        }

        protected override Product SaveWithOutValidation(Product product, Product productOld)
        {
            product = this.SaveDefault(product, productOld);
			this._cacheHelper.ClearCache();

			this._validationResult = product.GetDomainValidation();
			this._validationWarning = product.GetDomainWarning();
			if (!product.IsValid())
                return product;

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return product;
        }

		protected override Product SaveWithValidation(Product product, Product productOld)
        {
            if (!this.DataAnnotationIsValid())
                return product;

			this._validationResult = product.GetDomainValidation();
			this._validationWarning = product.GetDomainWarning();
			if (!product.IsValid())
				return product;

            this.Specifications(product);

            if (!this._validationResult.IsValid)
                return product;
            
            product = this.SaveDefault(product, productOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return product;
        }

		protected virtual void Specifications(Product product)
        {
            this._validationResult  = this._validationResult.Merge(new ProductIsSuitableValidation(this._rep).Validate(product));
			this._validationWarning  = this._validationWarning.Merge(new ProductIsSuitableWarning(this._rep).Validate(product));
        }

        protected virtual Product SaveDefault(Product product, Product productOld)
        {
			

            var isNew = productOld.IsNull();			
            if (isNew)
                product = this.AddDefault(product);
            else
				product = this.UpdateDefault(product);

            return product;
        }
		
        protected virtual Product AddDefault(Product product)
        {
            product = this._rep.Add(product);
            return product;
        }

		protected virtual Product UpdateDefault(Product product)
        {
            product = this._rep.Update(product);
            return product;
        }
				
		public virtual async Task<Product> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Product.ProductFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Product> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Product.ProductFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
