using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class SampleProductIsSuitableValidation : ValidatorSpecification<SampleProduct>
    {
        public SampleProductIsSuitableValidation(ISampleProductRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleProduct>(Instance of is suitable,"message for user"));
        }

    }
}
