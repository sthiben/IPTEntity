using IPTEntity.Models;
using IPTEntity.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IPTEntity.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
		{
			_logger = logger;
			_userManager = userManager;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult SolicitudEmpleo()
		{
			return View();
		}
		public IActionResult OfertaLaboral()
		{
			return View();
		}
		[HttpGet]
		public IActionResult EditarSolicitudEmpleo()
		{
			return View("EditarSolicitudEmpleo");
		}
		public IActionResult RegistroEmpresa()
		{
			var userId = _userManager.GetUserId(User);
			var empresaRegistrada = _context.Empresas.Any(e => e.UsuarioId == userId && e.EstaRegistrada);

			if (!empresaRegistrada)
			{
				return View();
			}
			return RedirectToAction("Index", "Home");
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}