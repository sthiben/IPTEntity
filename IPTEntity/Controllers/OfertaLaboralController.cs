using IPTEntity.Entidades;
using IPTEntity.Models;
using IPTEntity.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPTEntity.Controllers
{
	public class OfertaLaboralController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly IUserGetId _userGetId;

		public OfertaLaboralController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUserGetId userGetId)
		{
			_context = context;
			_hostEnvironment = hostEnvironment;
			_userGetId = userGetId;
		}

		[HttpPost]
		public async Task<IActionResult> CrearOfertaLaboral(OfertaLaboral ofertaLaboral)
		{
			ofertaLaboral.EmpresaId = _userGetId.getCurrentUserId();
			if (ModelState.IsValid)
			{
				_context.Add(ofertaLaboral);
				await _context.SaveChangesAsync();

				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("OfertaLaboral", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> ListadoOfertasLaborales()
		{
			var ofertasLaborales = await (from o in _context.OfertaLaboral
										  join e in _context.Empresas on o.EmpresaId equals e.EmpresaId
										  select new OfertaLaboralViewModel
										  {
											  EmpresaId = e.EmpresaId,
											  NombreEmpresa = e.NombreEmpresa,
											  TituloOferta = o.TituloOferta,
											  Profesion = o.Profesion,
										  }).ToListAsync();
			var modelo = new OfertasLaboralesListViewModel();
			modelo.OfertasLaborales = ofertasLaborales;
			return View(modelo);
		}

		[HttpPost]
		public async Task<IActionResult> FiltrarPorProfesion(string profesionSeleccionada)
		{
			if (!string.IsNullOrEmpty(profesionSeleccionada))
			{
				var ofertasFiltradas = await _context.OfertaLaboral
					.Where(o => o.Profesion == profesionSeleccionada)
					.ToListAsync();

				var ofertasViewModel = (from o in ofertasFiltradas
										join e in _context.Empresas on o.EmpresaId equals e.EmpresaId
										select new OfertaLaboralViewModel
										{
											EmpresaId = e.EmpresaId,
											NombreEmpresa = e.NombreEmpresa,
											TituloOferta = o.TituloOferta,
											Profesion = o.Profesion,
										}).ToList();

				var viewModel = new OfertasLaboralesListViewModel
				{
					OfertasLaborales = ofertasViewModel
				};

				return View("ListadoOfertasLaborales", viewModel);
			}
			//Aquí toca retornar una vista de error, si retorno nuevamente a OfertaLaboral se rompe porque tiene valores null.
			return RedirectToAction("ListadoOfertasLaborales", "OfertaLaboral");
		}

		[HttpGet]
		public async Task<IActionResult> EditarOfertaLaboral()
		{
			var usuarioActual = _userGetId.getCurrentUserId();

			var ofertaLaboral = await _context.OfertaLaboral.FirstOrDefaultAsync(ol => ol.EmpresaId == usuarioActual);

			if (ofertaLaboral  == null)
			{
				return RedirectToAction("OfertaLaboral", "Home");
			}
			return View("EditarOfertaLaboral", ofertaLaboral);
		}

		[HttpPost]

		public async Task<IActionResult> ActualizarOfertaLaboral(OfertaLaboral ofertaLaboralActualizada)
		{
			var empresaActual = _userGetId.getCurrentUserId();

			var ofertaLaboral = await _context.OfertaLaboral.FirstOrDefaultAsync(ol => ol.EmpresaId == empresaActual);

			if (ofertaLaboral != null)
			{

				ofertaLaboral.EmpresaId = empresaActual;
				ofertaLaboral.TituloOferta = ofertaLaboralActualizada.TituloOferta;
				ofertaLaboral.DescripcionOferta = ofertaLaboralActualizada.DescripcionOferta;
				ofertaLaboral.Profesion = ofertaLaboralActualizada.Profesion;

				_context.Update(ofertaLaboral);
				await _context.SaveChangesAsync();

				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction("OfertaLaboral", "Home");
		}

		[HttpGet]

		public async Task<IActionResult> ConfirmarEliminarOfertaLaboral()
		{

			var usuarioActual = _userGetId.getCurrentUserId();

			var ofertaLaboral = await _context.OfertaLaboral.FirstOrDefaultAsync(se => se.EmpresaId == usuarioActual);

			if (ofertaLaboral == null)
			{
				return RedirectToAction("Index", "Home");
			}

			return View("ConfirmarEliminarOfertaLaboral", ofertaLaboral);
		}


		[HttpPost]
		public async Task<IActionResult> EliminarOfertaLaboral()
		{
			var usuarioActual = _userGetId.getCurrentUserId();

			var ofertaLaboral = await _context.OfertaLaboral.FirstOrDefaultAsync(se => se.EmpresaId == usuarioActual);

			_context.OfertaLaboral.Remove(ofertaLaboral);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}

		[HttpPost]

		public async Task<IActionResult> VerInformacionEmpresa(string empresaId)
		{
			var datosEmpresa = await _context.Empresas.FindAsync(empresaId);

			if( datosEmpresa != null)
			{
				Empresas empresa = new Empresas();
				empresa.NombreEmpresa = datosEmpresa.NombreEmpresa;
				empresa.Direccion = datosEmpresa.Direccion;
				empresa.CorreoElectronico = datosEmpresa.CorreoElectronico;
				empresa.SitioWeb = datosEmpresa.SitioWeb;
				empresa.Telefono = datosEmpresa.Telefono;
				return View(empresa);
			}
			//Aquí toca mostrar una alerta
			return RedirectToAction("Index", "Home");
		}



	}
}
