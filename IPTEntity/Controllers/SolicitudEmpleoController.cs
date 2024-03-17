using Microsoft.AspNetCore.Mvc;
using IPTEntity.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using IPTEntity;
using Microsoft.Extensions.Hosting;
using IPTEntity.Models;
using IPTEntity.Servicios;

namespace IPTEntity.Controllers
{
	public class SolicitudEmpleoController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly IUserGetId _userGetId;

		public SolicitudEmpleoController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUserGetId userGetId)
		{
			_context = context;
			_hostEnvironment = hostEnvironment;
			_userGetId = userGetId;
		}

		[HttpPost]
		public async Task<IActionResult> Crear(SolicitudEmpleo solicitudEmpleo, IFormFile file)
		{
			if (ModelState.IsValid && file != null)
			{
				solicitudEmpleo.GuId = _userGetId.getCurrentUserId();

                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
				string uniqueFileName = solicitudEmpleo.GuId + "_" + file.FileName;
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