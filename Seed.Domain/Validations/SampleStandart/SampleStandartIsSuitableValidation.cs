using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class SampleStandartIsSuitableValidation : ValidatorSpecification<SampleStandart>
    {
        public SampleStandartIsSuitableValidation(ISampleStandartRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleStandart>(Instance of is suitable,"message for user"));
        }

    }
}
