using IPTEntity.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace IPTEntity.Controllers
{
	public class OfertaLaboralController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _hostEnvironment;

		public OfertaLaboralController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
		{
			_context = context;
			_hostEnvironment = hostEnvironment;
		}

		[HttpPost]
		public async Task<IActionResult> CrearOfertaLaboral(OfertaLaboral ofertaLaboral)
		{
			if (ModelState.IsValid )
			{
				_context.Add(ofertaLaboral);
				await _context.SaveChangesAsync();

				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("OfertaLaboral", "Home");
		}

	}
}
