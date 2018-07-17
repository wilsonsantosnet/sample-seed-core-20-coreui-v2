using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class SampleProductIsSuitableWarning : WarningSpecification<SampleProduct>
    {
        public SampleProductIsSuitableWarning(ISampleProductRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<SampleProduct>(Instance of suitable warning specification,"message for user"));
        }

    }
}
