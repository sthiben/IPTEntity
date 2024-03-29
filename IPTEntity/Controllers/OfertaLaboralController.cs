using IPTEntity.Entidades;
using IPTEntity.Models;
using IPTEntity.Servicios;
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
			if (ModelState.IsValid )
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
											  NombreEmpresa = e.NombreEmpresa,
											  TituloOferta = o.TituloOferta,
											  Profesion = o.Profesion,
										  }).ToListAsync();
			var modelo = new OfertasLaboralesListViewModel();
			modelo.OfertasLaborales = ofertasLaborales;
			return View(modelo);
		}


	}
}
