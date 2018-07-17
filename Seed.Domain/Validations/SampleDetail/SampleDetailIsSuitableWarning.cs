using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class SampleDetailIsSuitableWarning : WarningSpecification<SampleDetail>
    {
        public SampleDetailIsSuitableWarning(ISampleDetailRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleDetail>(Instance of suitable warning specification,"message for user"));
        }

    }
}
