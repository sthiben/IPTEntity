using Microsoft.EntityFrameworkCore;

namespace IPTEntity.Entidades
{
    public class ArchivoAdjunto
    {
        public Guid Id { get; set; }
        public int SolicitudEmpleoId { get; set; }
        public SolicitudEmpleo SolicitudEmpleo { get; set; }
        [Unicode]
        public string Url { get; set; }
        public string Titulo { get; set; }
        public int orden {  get; set; }
        public DateTime FechaCreacion { get; set; }



    }
}
