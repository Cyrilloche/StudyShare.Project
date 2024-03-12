using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkGroupName",
                table: "WorkGroups",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserPassword",
                table: "tbl_user",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserLastname",
                table: "tbl_user",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserFirstname",
                table: "tbl_user",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "tbl_user",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolName",
                table: "Schools",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "PaperVisibility",
                table: "Papers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "PaperPath",
                table: "Papers",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PaperName",
                table: "Papers",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PaperDescription",
                table: "Papers",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ClassLevelName",
                table: "ClassLevels",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ClassLevels",
                columns: new[] { "ClassLevelId", "ClassLevelName" },
                values: new object[,]
                {
                    { 6, "6ème" },
                    { 7, "5ème" },
                    { 8, "4ème" },
                    { 9, "3ème" },
                    { 10, "2nde" },
                    { 11, "1ère" },
                    { 12, "Terminale" }
                });

            migrationBuilder.InsertData(
                table: "Keywords",
                columns: new[] { "KeywordId", "KeywordName" },
                values: new object[,]
                {
                    { 1, "Français" },
                    { 2, "Maths" },
                    { 3, "Histoire" },
                    { 4, "Géographie" },
                    { 5, "Anglais" },
                    { 6, "EPS" },
                    { 7, "Musique" },
                    { 8, "Arts" },
                    { 9, "Sciences" },
                    { 10, "Physique" },
                    { 11, "Chimie" },
                    { 12, "Biologie" },
                    { 13, "Philosophie" },
                    { 14, "Économie" },
                    { 15, "Sociologie" },
                    { 16, "Informatique" },
                    { 17, "Technologie" },
                    { 18, "Espagnol" },
                    { 19, "Allemand" },
                    { 20, "Italien" },
                    { 21, "Chinois" },
                    { 22, "Russe" },
                    { 23, "Latin" },
                    { 24, "Grec" },
                    { 25, "Éthique" },
                    { 26, "Civisme" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ClassLevels",
                keyColumn: "ClassLevelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Keywords",
                keyColumn: "KeywordId",
                keyValue: 26);

            migrationBuilder.AlterColumn<string>(
                name: "WorkGroupName",
                table: "WorkGroups",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserPassword",
                table: "tbl_user",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserLastname",
                table: "tbl_user",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserFirstname",
                table: "tbl_user",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "tbl_user",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolName",
                table: "Schools",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "PaperVisibility",
                table: "Papers",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaperPath",
                table: "Papers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PaperName",
                table: "Papers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PaperDescription",
                table: "Papers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ClassLevelName",
                table: "ClassLevels",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
