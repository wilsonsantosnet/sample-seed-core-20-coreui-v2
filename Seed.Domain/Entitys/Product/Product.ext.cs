using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class Product : ProductBase
    {

        public Product()
        {

        }

        public Product(int productid, string name, string description) :
            base(productid, name, description)
        {

        }

		public class ProductFactory : ProductFactoryBase
        {
            public Product GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            return base._validationResult.Merge(new ProductIsConsistentValidation().Validate(this)).IsValid;
        }
        
    }
}
