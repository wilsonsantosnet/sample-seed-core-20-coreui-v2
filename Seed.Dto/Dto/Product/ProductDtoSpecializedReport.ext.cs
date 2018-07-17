using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seed.Dto
{
	public class ProductDtoSpecializedReport : ProductDto
	{

        public IEnumerable<SampleProductDto> CollectionSampleProduct { get; set;} 

		
	}
}