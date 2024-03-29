using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionOfertaLaboral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			{
				migrationBuilder.DropColumn(
					name: "NombreEmpresa",
					table: "OfertaLaboral");

				migrationBuilder.AddColumn<string>(
					name: "EmpresaId",
					table: "OfertaLaboral",
					nullable: true);
			}
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropColumn(
				name: "EmpresaId",
				table: "OfertaLaboral");

			migrationBuilder.AddColumn<string>(
				name: "NombreEmpresa",
				table: "OfertaLaboral",
				nullable: true);
		}
    }
}
