using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class AdicionCampoProfesionSolEmpleo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profesion",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profesion",
                table: "SolicitudEmpleos");
        }
    }
}
