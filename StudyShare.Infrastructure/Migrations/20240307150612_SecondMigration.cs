using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "tbl_user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "UserId",
                keyValue: 1,
                column: "UserRoleId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tbl_user",
                keyColumn: "UserId",
                keyValue: 2,
                column: "UserRoleId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "tbl_user");
        }
    }
}
