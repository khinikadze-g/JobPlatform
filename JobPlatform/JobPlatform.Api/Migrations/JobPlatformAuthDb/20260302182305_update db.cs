using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobPlatform.Api.Migrations.JobPlatformAuthDb
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13998812-1b92-4695-978e-ca4f18c679ee", "13998812-1b92-4695-978e-ca4f18c679ee", "Candidate", "Candidate" },
                    { "97269d64-32c5-4668-84db-909a69a73d04", "97269d64-32c5-4668-84db-909a69a73d04", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13998812-1b92-4695-978e-ca4f18c679ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97269d64-32c5-4668-84db-909a69a73d04");
        }
    }
}
