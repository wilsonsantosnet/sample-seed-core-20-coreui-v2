using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class SampleProductBase : DomainBase
    {
        public SampleProductBase()
        {

        }
        public SampleProductBase(int sampleid, int productid)
        {
            this.SampleId = sampleid;
            this.ProductId = productid;

        }

		public class SampleProductFactoryBase
        {
            public virtual SampleProduct GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new SampleProduct(data.SampleId,
                                        data.ProductId);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int SampleId { get; protected set; }
        public virtual int ProductId { get; protected set; }



    }
}
