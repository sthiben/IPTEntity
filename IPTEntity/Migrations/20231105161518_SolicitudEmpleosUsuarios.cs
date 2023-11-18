using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class SolicitudEmpleosUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UsuarioCreacionId",
                table: "SolicitudEmpleos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreP",
                table: "SolicitudEmpleos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResumenCV",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosCreacionId",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudEmpleos_UsuarioCreacionId",
                table: "SolicitudEmpleos",
                column: "UsuarioCreacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudEmpleos_AspNetUsers_UsuarioCreacionId",
                table: "SolicitudEmpleos",
                column: "UsuarioCreacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudEmpleos_AspNetUsers_UsuarioCreacionId",
                table: "SolicitudEmpleos");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudEmpleos_UsuarioCreacionId",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "ResumenCV",
                table: "SolicitudEmpleos");

            migrationBuilder.DropColumn(
                name: "UsuariosCreacionId",
                table: "SolicitudEmpleos");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioCreacionId",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreP",
                table: "SolicitudEmpleos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }
    }
}
