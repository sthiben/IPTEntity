using System.ComponentModel.DataAnnotations;

namespace IPTEntity.Entidades
{
	public class Empresas
	{
		[Key]
		public string EmpresaId { get; set; }
		[Required]
		public string NombreEmpresa { get; set; }

		public string Direccion { get; set; }

		public string Telefono { get; set; }

		public string CorreoElectronico { get; set; }

		public string SitioWeb { get; set; }

		public string UsuarioId { get; set; }

		public bool EstaRegistrada { get; set; } 


    }
}
