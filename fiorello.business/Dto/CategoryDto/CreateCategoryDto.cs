﻿using fiorello.entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Dto.CategoryDto
{
	public class CreateCategoryDto
	{

		public string? Name { get; set; }

		public int CategoryCount { get; set; }

	
		public Products? Product { get; set; }
	}
}
