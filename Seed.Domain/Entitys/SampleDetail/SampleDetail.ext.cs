using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class SampleDetail : SampleDetailBase
    {

        public SampleDetail()
        {

        }

        public SampleDetail(int sampledetailid, int sampleid, string name, string descricao) :
            base(sampledetailid, sampleid, name, descricao)
        {

        }

		public class SampleDetailFactory : SampleDetailFactoryBase
        {
            public SampleDetail GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            return base._validationResult.Merge(new SampleDetailIsConsistentValidation().Validate(this)).IsValid;
        }
        
    }
}
