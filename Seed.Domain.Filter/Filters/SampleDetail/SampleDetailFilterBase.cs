using Common.Domain.Base;
using System;

namespace Seed.Domain.Filter
{
    public class SampleDetailFilterBase : FilterBase
    {

        public virtual int SampleDetailId { get; set;} 
        public virtual int SampleId { get; set;} 
        public virtual string Name { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual DateTime? DataStart { get; set;} 
        public virtual DateTime? DataEnd { get; set;} 
        public virtual DateTime? Data { get; set;} 
        public virtual int UserCreateId { get; set;} 
        public virtual DateTime UserCreateDateStart { get; set;} 
        public virtual DateTime UserCreateDateEnd { get; set;} 
        public virtual DateTime UserCreateDate { get; set;} 
        public virtual int? UserAlterId { get; set;} 
        public virtual DateTime? UserAlterDateStart { get; set;} 
        public virtual DateTime? UserAlterDateEnd { get; set;} 
        public virtual DateTime? UserAlterDate { get; set;} 


    }
}
