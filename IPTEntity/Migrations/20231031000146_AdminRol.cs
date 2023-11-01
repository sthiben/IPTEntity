using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPTEntity.Migrations
{
    /// <inheritdoc />
    public partial class AdminRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF NOT EXISTS(Select Id from AspNetRoles where Id = 'b2370845-2b42-42ce-a8aa-499d97b7a612')
                                BEGIN
	                            INSERT AspNetRoles (Id, [Name], [Normalizedname])
	                            VALUES ('b2370845-2b42-42ce-a8aa-499d97b7a612', 'admin', 'ADMIN')
                                END");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles Where Id = 'b2370845-2b42-42ce-a8aa-499d97b7a612'");

        }
    }
}
