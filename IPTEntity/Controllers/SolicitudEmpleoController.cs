using Microsoft.AspNetCore.Mvc;
using IPTEntity.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using IPTEntity;
using Microsoft.Extensions.Hosting;

namespace IPTEntity.Controllers
{
	public class SolicitudEmpleoController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _hostEnvironment;

		public SolicitudEmpleoController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
		{
			_context = context;
			_hostEnvironment = hostEnvironment;
		}

		[HttpPost]
		public async Task<IActionResult> Crear(SolicitudEmpleo solicitudEmpleo, IFormFile file)
		{
			if (ModelState.IsValid && file != null)
			{
				string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
				string uniqueFileName = solicitudEmpleo.UsuarioId + "_" + file.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				solicitudEmpleo.EstadoEmpleado = (solicitudEmpleo.EstadoEmpleado.Contains("Empleado")) ? "Empleado" : "Desempleado";

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);

				}
				
				solicitudEmpleo.FileName = uniqueFileName;
				solicitudEmpleo.FilePath = filePath;

				_context.Add(solicitudEmpleo);
				await _context.SaveChangesAsync();

				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("SolicitudEmpleo", "Home");
		}
	}
}