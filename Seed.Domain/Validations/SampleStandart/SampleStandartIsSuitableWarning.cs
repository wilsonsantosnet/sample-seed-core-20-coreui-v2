using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class SampleStandartIsSuitableWarning : WarningSpecification<SampleStandart>
    {
        public SampleStandartIsSuitableWarning(ISampleStandartRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleStandart>(Instance of suitable warning specification,"message for user"));
        }

    }
}
