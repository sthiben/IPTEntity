using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class DiegoMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EstadoEmpleado",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDiscapacidad",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoEmpleado",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "TipoDiscapacidad",
                table: "SolicitudEmpleos");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
