using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class EmpresaRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF NOT EXISTS(Select Id from AspNetRoles Where Id = '774918d2-73c2-4132-903b-6acb557106a2')
                                 BEGIN
	                                    INSERT AspNetRoles(Id, [Name], [NormalizedName])
	                                    VALUES ('774918d2-73c2-4132-903b-6acb557106a2', 'empresa', 'EMPRESA')
                                 END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles Where Id = '774918d2-73c2-4132-903b-6acb557106a2'");
        }
    }
}
