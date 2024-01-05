using fiorello.entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Dto.CategoryDto
{
	public class UpdateCategoryDto
	{
		public string id { get; set; }	
		public string? Name { get; set; }

		public int CategoryCount { get; set; }

		
		public Products? Product { get; set; }
	}
}
