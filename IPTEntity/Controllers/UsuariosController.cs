using IPTEntity.Models;
using IPTEntity.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System.Runtime.InteropServices;

namespace IPTEntity.Controllers
{
	public class UsuariosController : Controller

	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;
		private readonly ApplicationDbContext context;
		public UsuariosController(UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.context = context;
		}
		[AllowAnonymous]
		public IActionResult Registro()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Registro(RegistroViewModel modelo)
		{
			if (!ModelState.IsValid)
			{
				return View(modelo);
			}

			var usuario = new IdentityUser() { Email = modelo.Email, UserName = modelo.Username };

			var resultado = await userManager.CreateAsync(usuario, password: modelo.Password);

			if (resultado.Succeeded)
			{
				await userManager.AddToRoleAsync(usuario, "usuario");

				await signInManager.SignInAsync(usuario, isPersistent: true);
				return RedirectToAction("Login", "Usuarios");
			}
			else
			{
				foreach (var error in resultado.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

				return View(modelo);
			}
		}
		[AllowAnonymous]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel modelo)
		{
			if (!ModelState.IsValid)
			{
				return View(modelo);
			}

			var user = await userManager.FindByEmailAsync(modelo.Email);
			var resultado = await signInManager.PasswordSignInAsync(user.UserName, modelo.Password, modelo.Recuerdame, lockoutOnFailure: false);

			if (resultado.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrecta.");
				return View(modelo);
			}

		}
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		[Authorize(Roles = Constantes.RolAdmin)]
		public async Task<IActionResult> Listado(string mensaje = null)
		{
			var usuarios = await context.Users.Select(u => new UsuarioViewModel
			{
				Email = u.Email,
				Username = u.UserName
			}).ToListAsync();
			var modelo = new UsuariosListadoViewModel();
			modelo.Usuarios = usuarios;
			modelo.Mensaje = mensaje;
			return View("listado", modelo);
		}
		[HttpPost]
		[Authorize(Roles = Constantes.RolAdmin)]
		public async Task<IActionResult> HacerAdmin(string email)
		{
			var usuario = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
			if (usuario is null)
			{
				return NotFound();
			}

			if (await userManager.IsInRoleAsync(usuario, "usuario"))
			{
				await userManager.RemoveFromRoleAsync(usuario, "usuario");
			}

			if (await userManager.IsInRoleAsync(usuario, "empresa"))
			{
				await userManager.RemoveFromRoleAsync(usuario, "empresa");
			}

			await userManager.AddToRoleAsync(usuario, Constantes.RolAdmin);
			return RedirectToAction("Listado", routeValues: new { mensaje = "Rol admin asignado correctamente a: " + email });
		}
		[HttpPost]
		[Authorize(Roles = Constantes.RolAdmin)]
		public async Task<IActionResult> RemoverAdmin(string email)
		{
			var usuario = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
			if (usuario is null)
			{
				return NotFound();
			}
			await userManager.RemoveFromRoleAsync(usuario, Constantes.RolAdmin);

			await userManager.AddToRoleAsync(usuario, "usuario");

			return RedirectToAction("Listado", routeValues: new { mensaje = "Rol admin removido correctamente a: " + email });
		}

		[HttpPost]
		[Authorize(Roles = Constantes.RolAdmin)]
		public async Task<IActionResult> HacerEmpresa(string email)
		{
			var usuario = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
			if (usuario is null)
			{
				return NotFound();
			}

			if (await userManager.IsInRoleAsync(usuario, "usuario"))
			{
				await userManager.RemoveFromRoleAsync(usuario, "usuario");
			}
			await userManager.AddToRoleAsync(usuario, Constantes.RolEmpresa);
			return RedirectToAction("Listado", routeValues: new { mensaje = "Rol Empresa asignado correctamente a: " + email });
		}
		[HttpPost]
		[Authorize(Roles = Constantes.RolAdmin)]
		public async Task<IActionResult> RemoverEmpresa(string email)
		{
			var usuario = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
			if (usuario is null)
			{
				return NotFound();
			}
			await userManager.RemoveFromRoleAsync(usuario, Constantes.RolEmpresa);

			await userManager.AddToRoleAsync(usuario, "usuario");

			return RedirectToAction("Listado", routeValues: new { mensaje = "Rol Empresa removido correctamente a: " + email });
		}
		[HttpGet]
		[Authorize(Roles = Constantes.RolEmpresa)]
		public async Task<IActionResult> ListadoUsuarios(string mensaje = null)
		{
			var usuarios = await context.Users.Select(u => new UsuarioViewModel
			{
				Email = u.Email,
				Username = u.UserName
			}).ToListAsync();
			var modelo = new UsuariosListadoViewModel();
			modelo.Usuarios = usuarios;
			modelo.Mensaje = mensaje;
			return View(modelo);
		}
	}
}
