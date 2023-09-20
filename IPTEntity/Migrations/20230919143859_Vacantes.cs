using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class Vacantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vacantes",
                columns: table => new
                {
                    VacanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizacionID = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPublicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacantes", x => x.VacanteId);
                    table.ForeignKey(
                        name: "FK_vacantes_Organizaciones_OrganizacionID",
                        column: x => x.OrganizacionID,
                        principalTable: "Organizaciones",
                        principalColumn: "OrganizacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vacantes_OrganizacionID",
                table: "vacantes",
                column: "OrganizacionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vacantes");
        }
    }
}
