using fiorello.business.Abstract;
using fiorello.business.Dto.CategoryDto;
using fiorello.data.Abstract;
using fiorello.entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Concrete
{
	public class CategoryService : ICategoryService
	{
		readonly private ICategoryReadRepository _categoryReadRepository;
		readonly private ICategoryWriteRepository _categoryWriteRepository;

		public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
		{
			_categoryReadRepository = categoryReadRepository;
			_categoryWriteRepository = categoryWriteRepository;
		}
		public async Task<bool> Create(CreateCategoryDto model)
		{


		var datas =	await _categoryReadRepository.GetAll()
														  .Include(a => a.Product)
				                                          .FirstOrDefaultAsync(ct => ct.Id == model.Product.CategoryId &&
														                       ct.Product.Id == model.Product.Id);  

			if (datas == null)
			{

				model.CategoryCount = 0 ;
			}
			else
			{
				model.CategoryCount++;
			}
			 
			Category category = new Category()
			{
				Name = model.Name,
			
				CategoryCount = model.CategoryCount,
			};

		 await 	_categoryWriteRepository.AddAsync(category);
			await _categoryWriteRepository.SaveAsync();
			return true;
		}

		public async Task<bool> Delete(string id)
		=>  await _categoryWriteRepository.RemoveAsync(id);

		public async Task<List<Category>> GetAll()
		{
			List<Category> categories = await _categoryReadRepository.GetAll().ToListAsync();

			return categories;
		}

		public async Task<Category> GetById(string id)
		=> await _categoryReadRepository.GetByIdAsync(id);

		public async Task<bool> Update(UpdateCategoryDto model)
		{
			var category = await _categoryReadRepository.GetByIdAsync(model.id);
			if (category == null) throw new Exception("Not Found");
			
			category.Name= model.Name;
			category.CategoryCount= model.CategoryCount;

			 _categoryWriteRepository.Update(category);
			await _categoryWriteRepository.SaveAsync();
			return true;
		}
	}
}
