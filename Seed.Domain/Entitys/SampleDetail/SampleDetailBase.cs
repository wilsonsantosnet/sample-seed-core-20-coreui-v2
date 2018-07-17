using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class SampleDetailBase : DomainBaseWithUserCreate
    {
        public SampleDetailBase()
        {

        }
        public SampleDetailBase(int sampledetailid, int sampleid, string name, string descricao)
        {
            this.SampleDetailId = sampledetailid;
            this.SampleId = sampleid;
            this.Name = name;
            this.Descricao = descricao;

        }

		public class SampleDetailFactoryBase
        {
            public virtual SampleDetail GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new SampleDetail(data.SampleDetailId,
                                        data.SampleId,
                                        data.Name,
                                        data.Descricao);

                construction.SetarData(data.Data);


				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int SampleDetailId { get; protected set; }
        public virtual int SampleId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual DateTime? Data { get; protected set; }

		public virtual void SetarData(DateTime? data)
		{
			this.Data = data;
		}


    }
}
