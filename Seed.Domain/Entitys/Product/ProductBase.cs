using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class ProductBase : DomainBase
    {
        public ProductBase()
        {

        }
        public ProductBase(int productid, string name, string description)
        {
            this.ProductId = productid;
            this.Name = name;
            this.Description = description;

        }

		public class ProductFactoryBase
        {
            public virtual Product GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Product(data.ProductId,
                                        data.Name,
                                        data.Description);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int ProductId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }



    }
}
