using fiorello.business.Abstract;
using fiorello.business.Dto.CategoryDto;
using fiorello.entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fiorello.webui.Areas.admin.Controllers
{
	[Area(nameof(admin))]
	public class CategoryController : Controller
	{

		readonly private ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public async Task<IActionResult> Index()
		{
			List<Category> categories = await _categoryService.GetAll();
			return View(categories);

		}

		public async Task<IActionResult >  Details(string id)
		{
			var category = await _categoryService.GetById(id);
			if(category == null) return NotFound();


			return View(category);
		}
		public IActionResult Create()
		=> View();
		[HttpPost]
		public async Task<IActionResult> Create (CreateCategoryDto model)
		{
			if (!ModelState.IsValid) return View(model);
			await _categoryService.Create(model);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(string id) {

			var category = await _categoryService.GetById(id);
			if (category == null) return NotFound();

			return View(category);
		
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateCategoryDto model)
		{

			if (!ModelState.IsValid) return View(model);


			var category = await _categoryService.GetAll();

			bool isReplayValue = category.Any(uc => uc.Name.ToLower().Trim() == model.Name.ToLower().Trim() && uc.Id!=Guid.Parse(model.id));

			if (isReplayValue)
			{
				ModelState.AddModelError("Name", "tekrarlanan alan ");
			}


			await _categoryService.Update(model);
			return RedirectToAction(nameof(Index));
		}
		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			var category = await _categoryService.GetById(id);
			if (category == null) return NotFound();
			await _categoryService.Delete(id);
			return RedirectToAction(nameof(Index));
		}


	}
}
