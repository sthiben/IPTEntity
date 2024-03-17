using IPTEntity.Entidades;
using IPTEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPTEntity.Controllers
{
	public class DescargarArchivoController : Controller
	{

		private readonly ApplicationDbContext _context;
		public IActionResult Index()
		{
			return View();
		}

		public DescargarArchivoController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult DescargarArchivo(string GuId)
		{
			var solicitudEmpleo = _context.SolicitudEmpleos.FirstOrDefault(se => se.GuId == GuId);

			if (solicitudEmpleo == null)
			{
				return NotFound();
			}

			var filePath = solicitudEmpleo.FilePath;
			var fileName = solicitudEmpleo.FileName;
			var mimeType = "application/pdf";

			filePath = Path.Combine(filePath);

			if (!System.IO.File.Exists(filePath))
			{
				ModelState.AddModelError(string.Empty, "El archivo no existe");
				return View("Error", "Shared");
			}

			var fileBytes = System.IO.File.ReadAllBytes(filePath);
			Console.WriteLine(fileBytes);
			return File(fileBytes, mimeType, fileName);
		}
	}
}
