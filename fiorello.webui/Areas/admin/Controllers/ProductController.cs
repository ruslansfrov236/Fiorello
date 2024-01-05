using fiorello.business.Abstract;
using fiorello.business.Dto.CategoryDto;
using fiorello.business.Dto.ProductDto;
using fiorello.entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace fiorello.webui.Areas.admin.Controllers
{
	[Area(nameof(admin))]
	public class ProductController : Controller
	{
		readonly private IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		public async Task<IActionResult> Index()
		{
			List<Products> products = await _productService.GetAll();
			return View(products);
		}

		public async Task<IActionResult> Details(string id)
		{
			var product = await _productService.GetById(id);
			if (product == null) return NotFound();
			return View(product);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		=> View();

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductDto model)
		{


			if (!ModelState.IsValid) return View(model);
			await _productService.Create(model);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(string id)
		{
			var products = await _productService.GetById(id);

			if (products == null) return NotFound();

			return View(products);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateProductDto model)
		{
			if (!ModelState.IsValid) return View(model);
			var products = await _productService.GetAll();

			await _productService.Update(model);
			return RedirectToAction(nameof(Index));
		}
		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			var product = await _productService.GetById(id);

			if (product == null) return NotFound();

			await _productService.Delete(id);
			return RedirectToAction(nameof(Index));

		}
	}
}
