using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class Sample : SampleBase
    {
        public virtual SampleStandart SampleStandart { get; protected set; }

        public Sample()
        {

        }

        public Sample(int sampleid, string name, int sampletypeid) :
            base(sampleid, name, sampletypeid)
        {

        }

		public class SampleFactory : SampleFactoryBase
        {
            public Sample GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            return base._validationResult.Merge(new SampleIsConsistentValidation().Validate(this)).IsValid;
        }
        
    }
}
