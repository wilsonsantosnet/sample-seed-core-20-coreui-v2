using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class ProductIsSuitableValidation : ValidatorSpecification<Product>
    {
        public ProductIsSuitableValidation(IProductRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Product>(Instance of is suitable,"message for user"));
        }

    }
}
