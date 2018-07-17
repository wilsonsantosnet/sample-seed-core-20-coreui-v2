using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class SampleDetailIsSuitableValidation : ValidatorSpecification<SampleDetail>
    {
        public SampleDetailIsSuitableValidation(ISampleDetailRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleDetail>(Instance of is suitable,"message for user"));
        }

    }
}
