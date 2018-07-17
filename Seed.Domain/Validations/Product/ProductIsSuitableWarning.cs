using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class ProductIsSuitableWarning : WarningSpecification<Product>
    {
        public ProductIsSuitableWarning(IProductRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Product>(Instance of suitable warning specification,"message for user"));
        }

    }
}
