using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class SolicitudesEmpleos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacantes_Organizaciones_OrganizacionID",
                table: "vacantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vacantes",
                table: "vacantes");

            migrationBuilder.RenameTable(
                name: "vacantes",
                newName: "Vacantes");

            migrationBuilder.RenameIndex(
                name: "IX_vacantes_OrganizacionID",
                table: "Vacantes",
                newName: "IX_Vacantes_OrganizacionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacantes",
                table: "Vacantes",
                column: "VacanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacantes_Organizaciones_OrganizacionID",
                table: "Vacantes",
                column: "OrganizacionID",
                principalTable: "Organizaciones",
                principalColumn: "OrganizacionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacantes_Organizaciones_OrganizacionID",
                table: "Vacantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacantes",
                table: "Vacantes");

            migrationBuilder.RenameTable(
                name: "Vacantes",
                newName: "vacantes");

            migrationBuilder.RenameIndex(
                name: "IX_Vacantes_OrganizacionID",
                table: "vacantes",
                newName: "IX_vacantes_OrganizacionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vacantes",
                table: "vacantes",
                column: "VacanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacantes_Organizaciones_OrganizacionID",
                table: "vacantes",
                column: "OrganizacionID",
                principalTable: "Organizaciones",
                principalColumn: "OrganizacionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
