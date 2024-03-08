using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SchoolClassLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassLevels",
                columns: new[] { "ClassLevelId", "ClassLevelName" },
                values: new object[,]
                {
                    { 1, "CP" },
                    { 2, "CE1" },
                    { 3, "CE2" },
                    { 4, "CM1" },
                    { 5, "CM2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 5);
        }
    }
}
