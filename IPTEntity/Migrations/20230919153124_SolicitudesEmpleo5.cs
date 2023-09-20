using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class SolicitudesEmpleo5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudEmpleos_VacanteId1",
                table: "SolicitudEmpleos",
                column: "VacanteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudEmpleos_Vacantes_VacanteId1",
                table: "SolicitudEmpleos",
                column: "VacanteId1",
                principalTable: "Vacantes",
                principalColumn: "VacanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudEmpleos_Vacantes_VacanteId1",
                table: "SolicitudEmpleos");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudEmpleos_VacanteId1",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "VacanteId",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "VacanteId1",
                table: "SolicitudEmpleos");
        }
    }
}
