using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class AdicionTablaEmpresas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "Empresas",
				columns: table => new
				{
					EmpresaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropTable(
				name: "Empresas"
				);
		}
    }
}
