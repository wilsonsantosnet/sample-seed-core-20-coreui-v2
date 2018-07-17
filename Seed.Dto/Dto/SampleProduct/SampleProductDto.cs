using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Seed.Dto
{
	public class SampleProductDto  : DtoBase
	{
	
        

        public virtual int SampleId {get; set;}

        

        public virtual int ProductId {get; set;}


		
	}
}