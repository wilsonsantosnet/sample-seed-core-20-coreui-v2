using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class ProductIsConsistentValidation : ValidatorSpecification<Product>
    {
        public ProductIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Product>(Instance of is consistent specification,"message for user"));
        }

    }
}
