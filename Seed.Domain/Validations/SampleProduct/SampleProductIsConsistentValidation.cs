using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class SampleProductIsConsistentValidation : ValidatorSpecification<SampleProduct>
    {
        public SampleProductIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleProduct>(Instance of is consistent specification,"message for user"));
        }

    }
}
