using Microsoft.AspNetCore.Mvc;
using IPTEntity.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using IPTEntity;

namespace TuProyecto.Controllers
{
	public class SolicitudEmpleoController : Controller
	{
		private readonly ApplicationDbContext _context;

		public SolicitudEmpleoController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> Crear(SolicitudEmpleo solicitudEmpleo)
		{
			if (ModelState.IsValid)
			{
				_context.Add(solicitudEmpleo);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index", "Home"); // Cambia "Index" y "Home" según tu ruta de inicio
			}
			return RedirectToAction("SolicitudEmpleo", "Home");
		}
	}
}