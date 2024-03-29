using IPTEntity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IPTEntity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
   
    }
}