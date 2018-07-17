using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class SampleDetailIsConsistentValidation : ValidatorSpecification<SampleDetail>
    {
        public SampleDetailIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleDetail>(Instance of is consistent specification,"message for user"));
        }

    }
}
