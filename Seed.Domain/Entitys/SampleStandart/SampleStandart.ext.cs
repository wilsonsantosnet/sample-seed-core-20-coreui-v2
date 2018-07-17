using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class SampleStandart : SampleStandartBase
    {

        public virtual Sample Sample { get; protected set; }

        public SampleStandart()
        {

        }

        public SampleStandart(int samplestandartid, string name) :
            base(samplestandartid, name)
        {

        }

		public class SampleStandartFactory : SampleStandartFactoryBase
        {
            public SampleStandart GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            return base._validationResult.Merge(new SampleStandartIsConsistentValidation().Validate(this)).IsValid;
        }
        
    }
}
