using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
	/// <inheritdoc />
	public partial class AddOfertaLaboralEntity : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "EstadoEmpleado",
				table: "SolicitudEmpleos",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.CreateTable(
				name: "OfertaLaboral",
				columns: table => new
				{
					OfertaId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
					TituloOferta = table.Column<string>(type: "nvarchar(max)", nullable: true),
					DescripcionOferta = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Profesion = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OfertaLaboral", x => x.OfertaId);
				});

			{
				migrationBuilder.InsertData(
					table: "AspNetRoles",
					columns: new[] { "Id", "Name", "NormalizedName" },
					values: new object[] { "ad932422-deae-4be2-8ef9-dd7e8881e418", "usuario", "USUARIO" });
			}
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "OfertaLaboral");

			migrationBuilder.AlterColumn<string>(
				name: "EstadoEmpleado",
				table: "SolicitudEmpleos",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			{
				migrationBuilder.DeleteData(
					table: "AspNetRoles",
					keyColumn: "Id",
					keyValue: "ad932422-deae-4be2-8ef9-dd7e8881e418"); 
			}
		}
	}
}
