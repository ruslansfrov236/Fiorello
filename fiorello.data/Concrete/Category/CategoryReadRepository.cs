using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fiorello.data.Abstract;
using fiorello.data.Context;
using fiorello.entity.Entities;
namespace fiorello.data.Concrete
{
	public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
	{
		public CategoryReadRepository(FiorrelloDbContext context) : base(context)
		{
		}
	}
}
