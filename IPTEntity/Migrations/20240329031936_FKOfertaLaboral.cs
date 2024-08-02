using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class FKOfertaLaboral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateIndex(
				name: "IX_OfertaLaboral_EmpresaId",
				table: "OfertaLaboral",
				column: "EmpresaId");

			migrationBuilder.AddForeignKey(
				name: "FK_OfertaLaboral_Empresas_EmpresaId",
				table: "OfertaLaboral",
				column: "EmpresaId",
				principalTable: "Empresas",
				principalColumn: "EmpresaId",
				onDelete: ReferentialAction.Restrict);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropForeignKey(
				name: "FK_OfertaLaboral_Empresas_EmpresaId",
				table: "OfertaLaboral");

			migrationBuilder.DropIndex(
				name: "IX_OfertaLaboral_EmpresaId",
				table: "OfertaLaboral");
		}
    }
}
