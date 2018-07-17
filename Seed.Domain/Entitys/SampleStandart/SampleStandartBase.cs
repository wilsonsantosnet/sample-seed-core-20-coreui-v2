using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class SampleStandartBase : DomainBase
    {
        public SampleStandartBase()
        {

        }
        public SampleStandartBase(int samplestandartid, string name)
        {
            this.SampleStandartId = samplestandartid;
            this.Name = name;

        }

		public class SampleStandartFactoryBase
        {
            public virtual SampleStandart GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new SampleStandart(data.SampleStandartId,
                                        data.Name);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int SampleStandartId { get; protected set; }
        public virtual string Name { get; protected set; }



    }
}
