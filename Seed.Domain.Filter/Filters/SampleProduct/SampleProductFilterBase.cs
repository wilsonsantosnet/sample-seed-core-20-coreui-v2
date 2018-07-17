using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class SampleProductFilterBase : FilterBase
    {

        public virtual int SampleId { get; set;} 
        public virtual int ProductId { get; set;} 


    }
}
