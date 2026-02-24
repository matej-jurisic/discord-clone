using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Servers.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedServerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "servers",
                table: "Servers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1L, "My description", "Default Server" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "servers",
                table: "Servers",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
