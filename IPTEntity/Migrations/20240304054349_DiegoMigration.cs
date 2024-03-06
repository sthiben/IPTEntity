using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class DiegoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudEmpleos_AspNetUsers_UsuarioCreacionId",
                table: "SolicitudEmpleos");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudEmpleos_Vacantes_VacanteId1",
                table: "SolicitudEmpleos");

            migrationBuilder.DropTable(
                name: "ArchivoAdjunto");

            migrationBuilder.DropTable(
                name: "Vacantes");

            migrationBuilder.DropTable(
                name: "Organizaciones");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudEmpleos_UsuarioCreacionId",
                table: "SolicitudEmpleos");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudEmpleos_VacanteId1",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "NombreP",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "Orden",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacionId",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "UsuariosCreacionId",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "VacanteId",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "VacanteId1",
                table: "SolicitudEmpleos");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "SolicitudEmpleos");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreP",
                table: "SolicitudEmpleos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Orden",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacionId",
                table: "SolicitudEmpleos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosCreacionId",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacanteId",
                table: "SolicitudEmpleos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VacanteId1",
                table: "SolicitudEmpleos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArchivoAdjunto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolicitudEmpleoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orden = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Organizaciones",
                columns: table => new
                {
                    OrganizacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaginaWeb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizaciones", x => x.OrganizacionID);
                });

            migrationBuilder.CreateTable(
                name: "Vacantes",
                columns: table => new
                {
                    VacanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizacionID = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPublicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacantes", x => x.VacanteId);
                    table.ForeignKey(
                        name: "FK_Vacantes_Organizaciones_OrganizacionID",
                        column: x => x.OrganizacionID,
                        principalTable: "Organizaciones",
                        principalColumn: "OrganizacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudEmpleos_UsuarioCreacionId",
                table: "SolicitudEmpleos",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudEmpleos_VacanteId1",
                table: "SolicitudEmpleos",
                column: "VacanteId1");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoAdjunto_SolicitudEmpleoId",
                table: "ArchivoAdjunto",
                column: "SolicitudEmpleoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacantes_OrganizacionID",
                table: "Vacantes",
                column: "OrganizacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudEmpleos_AspNetUsers_UsuarioCreacionId",
                table: "SolicitudEmpleos",
                column: "UsuarioCreacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudEmpleos_Vacantes_VacanteId1",
                table: "SolicitudEmpleos",
                column: "VacanteId1",
                principalTable: "Vacantes",
                principalColumn: "VacanteId");
        }
    }
}
