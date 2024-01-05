using fiorello.business.Abstract;
using fiorello.entity.Entities;
using fiorello.webui.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace fiorello.webui.Controllers
{
	public class HomeController : Controller
	{

		readonly private IProductService _productService;
		readonly private IHeaderService _headerService;

		public HomeController(IHeaderService headerService, IProductService productService)
		{
			_headerService = headerService;
			_productService = productService;
		}
		public async Task<IActionResult> Index()
		{
			var products = await _productService.GetAll();
			var header = await _headerService.GetAllAsync();

			HomeIndexVM homeIndexVM = new HomeIndexVM()
			{
				Header= header,
				Products = products,	

			};

			return View(homeIndexVM);
		}
	}
}
