using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class RelacionEmpresasUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<string>(
				name: "UsuarioId",
				table: "Empresas",
				type: "nvarchar(450)",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Empresas_UsuarioId",
				table: "Empresas",
				column: "UsuarioId");

			migrationBuilder.AddForeignKey(
				name: "FK_Empresas_Usuarios_UsuarioId",
				table: "Empresas",
				column: "UsuarioId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropForeignKey(
				name: "FK_Empresas_Usuarios_UsuarioId",
				table: "Empresas");

			migrationBuilder.DropIndex(
				name: "IX_Empresas_UsuarioId",
				table: "Empresas");

			migrationBuilder.DropColumn(
				name: "UsuarioId",
				table: "Empresas");
		}
    }
}
