using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class CambioTipoDeDatoGuId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AlterColumn<string>(
	        name: "GuId",
	        table: "SolicitudEmpleos",
	        type: "nvarchar(450)",
	        nullable: true,
	        oldClrType: typeof(string),
	        oldType: "nvarchar(max)");

		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
