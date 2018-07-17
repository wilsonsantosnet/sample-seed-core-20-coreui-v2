using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seed.Dto
{
	public class SampleProductDtoSpecialized : SampleProductDto
	{

        public  ProductDto Product { get; set;} 
        public  SampleDto Sample { get; set;} 

		
	}
}