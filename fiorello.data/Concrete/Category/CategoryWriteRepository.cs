using fiorello.data.Abstract;
using fiorello.data.Context;
using fiorello.entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.data.Concrete
{
	internal class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
	{
		public CategoryWriteRepository(FiorrelloDbContext context) : base(context)
		{
		}
	}
}
