using Microsoft.AspNetCore.Mvc;
using IPTEntity.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using IPTEntity;
using Microsoft.Extensions.Hosting;
using IPTEntity.Models;
using IPTEntity.Servicios;
using Microsoft.AspNetCore.Identity;

namespace IPTEntity.Controllers
{
	public class SolicitudEmpleoController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly IUserGetId _userGetId;
		private readonly UserManager<IdentityUser> _userManager;

		public SolicitudEmpleoController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUserGetId userGetId, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_hostEnvironment = hostEnvironment;
			_userGetId = userGetId;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> Crear(SolicitudEmpleo solicitudEmpleo, IFormFile file)
		{

			var usuarioActual = await _userManager.GetUserAsync(User);
			var existeLaSolicitud = await _context.SolicitudEmpleos.FirstOrDefaultAsync(se => se.GuId == usuarioActual.Id);

			if( existeLaSolicitud != null)
			{
				return RedirectToAction("Index", "Home");
			}

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


		[HttpGet]
		public async Task<IActionResult> EditarSolicitudEmpleo()
		{
			var usuarioActual = await _userManager.GetUserAsync(User);

			var solicitudEmpleo = await _context.SolicitudEmpleos.FirstOrDefaultAsync(se => se.GuId == usuarioActual.Id);

			solicitudEmpleo.FileName = solicitudEmpleo.FileName.Split('_')[1];

			if (solicitudEmpleo  == null)
			{
				return RedirectToAction("SolicitudEmpleo", "Home");
			}
			return View("EditarSolicitudEmpleo", solicitudEmpleo);
		}

		[HttpPost]
		public async Task<IActionResult> ActualizarSolicitudEmpleo(SolicitudEmpleo solicitudEmpleoActualizada, IFormFile file)
		{

			var usuarioActual = await _userManager.GetUserAsync(User);

			var solicitudEmpleo = await _context.SolicitudEmpleos.FirstOrDefaultAsync(se => se.GuId == usuarioActual.Id);
			solicitudEmpleo.GuId = _userGetId.getCurrentUserId();

			string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
			string uniqueFileName = solicitudEmpleo.GuId + "_" + file.FileName;
			string filePath = Path.Combine(uploadsFolder, uniqueFileName);

			if (file != null)
			{
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);

				}

				solicitudEmpleo.UsuarioId = solicitudEmpleoActualizada.UsuarioId;

				solicitudEmpleo.Nombres = solicitudEmpleoActualizada.Nombres;

				solicitudEmpleo.Apellidos = solicitudEmpleoActualizada.Apellidos;

				solicitudEmpleo.Profesion = solicitudEmpleoActualizada.Profesion;

				solicitudEmpleo.ResumenCV = solicitudEmpleoActualizada.ResumenCV;

				solicitudEmpleo.FileName = uniqueFileName;

				solicitudEmpleo.FilePath = Path.Combine(uploadsFolder, uniqueFileName);

				solicitudEmpleo.FechaSolicitud = solicitudEmpleoActualizada.FechaSolicitud;

				solicitudEmpleo.TipoDiscapacidad = solicitudEmpleoActualizada.TipoDiscapacidad;

				solicitudEmpleo.EstadoEmpleado = solicitudEmpleoActualizada.EstadoEmpleado;

				_context.Update(solicitudEmpleo);
				await _context.SaveChangesAsync();

				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction("SolicitudEmpleo", "Home");

		}

		[HttpGet]

		public async Task<IActionResult> ConfirmarEliminarSolicitudEmpleo()
		{

			var usuarioActual = await _userManager.GetUserAsync(User);

			var solicitudEmpleo = await _context.SolicitudEmpleos.FirstOrDefaultAsync(se => se.GuId == usuarioActual.Id);

			if (solicitudEmpleo == null)
			{
				return RedirectToAction("Index", "Home");
			}

			return View("ConfirmarEliminarSolicitudEmpleo", solicitudEmpleo);
		}

		[HttpPost]
		public async Task<IActionResult> EliminarSolicitudEmpleo()
		{
			var usuarioActual = await _userManager.GetUserAsync(User);

			var solicitudEmpleo = await _context.SolicitudEmpleos.FirstOrDefaultAsync(se => se.GuId == usuarioActual.Id);

			_context.SolicitudEmpleos.Remove(solicitudEmpleo);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}


	}
}
