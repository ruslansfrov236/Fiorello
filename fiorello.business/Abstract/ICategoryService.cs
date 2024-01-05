using fiorello.business.Dto.CategoryDto;
using fiorello.business.Dto.ProductDto;
using fiorello.entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Abstract
{
	public interface ICategoryService
	{
		Task<List<Category>> GetAll();
		Task<Category> GetById(string id);

		Task<bool> Create(CreateCategoryDto model);
		Task<bool> Update(UpdateCategoryDto model);

		Task<bool> Delete(string id);
	}
}
