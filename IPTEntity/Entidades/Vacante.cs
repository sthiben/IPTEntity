namespace IPTEntity.Entidades
{
    public class Vacante
    {
        public Guid VacanteId { get; set; }
        public int OrganizacionID {  get; set; }
        public Organizacion Organizacion { get; set;}
        public string Cargo { get; set;}
        public string Descripcion { get; set;}
        public string FechaPublicacion { get; set; }

        public string Estado { get; set;}

        public int Salario { get; set;}
        public List<SolicitudEmpleo> SolicitudEmpleos { get; set;}

    }
}
