using IPTEntity.Entidades;
using IPTEntity.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;

namespace IPTEntity.Controllers
{
	public class RegistroEmpresaController : Controller
	{

		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly IUserGetId _userGetId;
		private readonly UserManager<IdentityUser> _userManager;

		public RegistroEmpresaController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IUserGetId userGetId, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_hostEnvironment = hostEnvironment;
			_userGetId = userGetId;
			_userManager = userManager;
		}


		[HttpPost]
		public async Task<IActionResult> Registro(Empresas empresa)
		{

			var empresaActual = await _userManager.GetUserAsync(User);
			empresa.EmpresaId = empresaActual.Id;
			empresa.UsuarioId = empresa.EmpresaId;

			if (ModelState.IsValid)
			{
				empresa.EstaRegistrada = true;
				_context.Add(empresa);
				await _context.SaveChangesAsync();
				TempData["Status"] = "success";
				TempData["Mensaje"] = "Empresa registrada con éxito";
				return View("~/Views/Home/RegistroEmpresa.cshtml");
			}
			TempData["Status"] = "error";
			TempData["Mensaje"] = "Error al registrar la empresa";
			return View("~/Views/Home/RegistroEmpresa.cshtml");
		}
	}
}
