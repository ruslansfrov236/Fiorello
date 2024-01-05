using Microsoft.AspNetCore.Mvc;

namespace fiorello.webui.Areas.admin.Controllers
{
	[Area(nameof(admin))]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
