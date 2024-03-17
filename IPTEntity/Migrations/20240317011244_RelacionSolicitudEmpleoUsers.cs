using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class RelacionSolicitudEmpleoUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddForeignKey(
	            name: "FK_SolicitudEmpleos_AspNetUsers_UserId",
	            table: "SolicitudEmpleos",
	            column: "GuId",
	            principalTable: "AspNetUsers",
	            principalColumn: "Id",
	            onDelete: ReferentialAction.Cascade);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
