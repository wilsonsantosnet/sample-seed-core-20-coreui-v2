using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seed.Dto
{
	public class ProductDtoSpecializedResult : ProductDto
	{

        public IEnumerable<SampleProductDto> CollectionSampleProduct { get; set;} 

		
	}
}