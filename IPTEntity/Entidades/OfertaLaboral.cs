using System.ComponentModel.DataAnnotations;

namespace IPTEntity.Entidades
{
	public class OfertaLaboral
	{
		[Key]
		public int OfertaId { get; set; }
		public string NombreEmpresa { get; set; }
		public string TituloOferta { get; set; }
		public string DescripcionOferta { get; set; }
		public string Profesion { get; set; }
		//public string TipoDiscapacidad { get; set; }

	}
}
