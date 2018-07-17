using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class SampleProduct : SampleProductBase
    {

        public SampleProduct()
        {

        }

        public SampleProduct(int sampleid, int productid) :
            base(sampleid, productid)
        {

        }

		public class SampleProductFactory : SampleProductFactoryBase
        {
            public SampleProduct GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            return base._validationResult.Merge(new SampleProductIsConsistentValidation().Validate(this)).IsValid;
        }
        
    }
}
