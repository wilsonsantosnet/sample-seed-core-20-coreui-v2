using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class ProductFilterBase : FilterBase
    {

        public virtual int ProductId { get; set;} 
        public virtual string Name { get; set;} 
        public virtual string Description { get; set;} 


    }
}
