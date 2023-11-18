using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class ArchivosAdjuntos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVUrl",
                table: "SolicitudEmpleos");

            migrationBuilder.AddColumn<string>(
                name: "Orden",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacionId",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArchivoAdjunto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolicitudEmpleoId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orden = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoAdjunto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivoAdjunto_SolicitudEmpleos_SolicitudEmpleoId",
                        column: x => x.SolicitudEmpleoId,
                        principalTable: "SolicitudEmpleos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoAdjunto_SolicitudEmpleoId",
                table: "ArchivoAdjunto",
                column: "SolicitudEmpleoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivoAdjunto");

            migrationBuilder.DropColumn(
                name: "Orden",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacionId",
                table: "SolicitudEmpleos");

            migrationBuilder.AddColumn<string>(
                name: "CVUrl",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
