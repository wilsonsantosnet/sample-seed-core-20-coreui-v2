using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class SampleStandartIsConsistentValidation : ValidatorSpecification<SampleStandart>
    {
        public SampleStandartIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleStandart>(Instance of is consistent specification,"message for user"));
        }

    }
}
