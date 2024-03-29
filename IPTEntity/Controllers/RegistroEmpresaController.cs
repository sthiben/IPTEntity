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
			empresa.EstaRegistrada = true;
			empresa.UsuarioId = empresa.EmpresaId;

			if (ModelState.IsValid)
			{
				_context.Add(empresa);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction("RegistroEmpresa", "Home");
		}
	}
}
