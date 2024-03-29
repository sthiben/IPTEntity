using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPTEntity.Entidades
{
	public class OfertaLaboral
	{
		[Key]
		public int OfertaId { get; set; }
		[ForeignKey("Empresas")]
		public string EmpresaId { get; set; }
		public string TituloOferta { get; set; }
		public string DescripcionOferta { get; set; }
		public string Profesion { get; set; }

	}
}
