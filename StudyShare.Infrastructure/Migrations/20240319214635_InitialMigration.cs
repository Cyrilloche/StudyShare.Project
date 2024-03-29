﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassLevels",
                columns: table => new
                {
                    ClassLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassLevelName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLevels", x => x.ClassLevelId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    KeywordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KeywordName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.KeywordId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserLastname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserFirstname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserPassword = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkGroups",
                columns: table => new
                {
                    WorkGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorkGroupName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroups", x => x.WorkGroupId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    PaperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PaperName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaperDescription = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaperPath = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaperUploadDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    PaperDownloadsNumber = table.Column<int>(type: "int", nullable: false),
                    PaperVisibility = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.PaperId);
                    table.ForeignKey(
                        name: "FK_Papers_tbl_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserClassLevels",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClassLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClassLevels", x => new { x.UserId, x.ClassLevelId });
                    table.ForeignKey(
                        name: "FK_UserClassLevels_ClassLevels_ClassLevelId",
                        column: x => x.ClassLevelId,
                        principalTable: "ClassLevels",
                        principalColumn: "ClassLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClassLevels_tbl_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserSchools",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSchools", x => new { x.UserId, x.SchoolId });
                    table.ForeignKey(
                        name: "FK_UserSchools_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSchools_tbl_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserWorkGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WorkGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkGroups", x => new { x.UserId, x.WorkGroupId });
                    table.ForeignKey(
                        name: "FK_UserWorkGroups_WorkGroups_WorkGroupId",
                        column: x => x.WorkGroupId,
                        principalTable: "WorkGroups",
                        principalColumn: "WorkGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkGroups_tbl_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaperClassLevels",
                columns: table => new
                {
                    PaperId = table.Column<int>(type: "int", nullable: false),
                    ClassLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperClassLevels", x => new { x.PaperId, x.ClassLevelId });
                    table.ForeignKey(
                        name: "FK_PaperClassLevels_ClassLevels_ClassLevelId",
                        column: x => x.ClassLevelId,
                        principalTable: "ClassLevels",
                        principalColumn: "ClassLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaperClassLevels_Papers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaperKeywords",
                columns: table => new
                {
                    PaperId = table.Column<int>(type: "int", nullable: false),
                    KeywordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperKeywords", x => new { x.PaperId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_PaperKeywords_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keywords",
                        principalColumn: "KeywordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaperKeywords_Papers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ClassLevels",
                columns: new[] { "ClassLevelId", "ClassLevelName" },
                values: new object[,]
                {
                    { 1, "CP" },
                    { 2, "CE1" },
                    { 3, "CE2" },
                    { 4, "CM1" },
                    { 5, "CM2" },
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
                    { 1, "Lecture" },
                    { 2, "Écriture" },
                    { 3, "Grammaire" },
                    { 4, "Conjugaison" },
                    { 5, "Orthographe" },
                    { 6, "Vocabulaire" },
                    { 7, "Récit" },
                    { 8, "Poésie" },
                    { 9, "Résumé" },
                    { 10, "Dissertation" },
                    { 11, "Calcul" },
                    { 12, "Numération" },
                    { 13, "Géométrie" },
                    { 14, "Algèbre" },
                    { 15, "Proportionnalité" },
                    { 16, "Statistiques" },
                    { 17, "Probabilités" },
                    { 18, "Équations" },
                    { 19, "Inéquations" },
                    { 20, "Fonctions" },
                    { 21, "Préhistoire" },
                    { 22, "Antiquité" },
                    { 23, "Moyen Âge" },
                    { 24, "Renaissance" },
                    { 25, "Révolutions" },
                    { 26, "Guerres mondiales" },
                    { 27, "Décolonisation" },
                    { 28, "Histoire de France" },
                    { 29, "Histoire du monde" },
                    { 30, "Civilisations" },
                    { 31, "Cartographie" },
                    { 32, "Relief" },
                    { 33, "Climat" },
                    { 34, "Environnement" },
                    { 35, "Population" },
                    { 36, "Développement durable" },
                    { 37, "Mondialisation" },
                    { 38, "Géopolitique" },
                    { 39, "Ressources naturelles" },
                    { 40, "Aménagement du territoire" },
                    { 41, "Vocabulaire" },
                    { 42, "Grammaire" },
                    { 43, "Conjugaison" },
                    { 44, "Compréhension écrite" },
                    { 45, "Compréhension orale" },
                    { 46, "Expression écrite" },
                    { 47, "Expression orale" },
                    { 48, "Traduction" },
                    { 49, "Civilisation anglophone" },
                    { 50, "Langue des affaires" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaperClassLevels_ClassLevelId",
                table: "PaperClassLevels",
                column: "ClassLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperKeywords_KeywordId",
                table: "PaperKeywords",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_UserId",
                table: "Papers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClassLevels_ClassLevelId",
                table: "UserClassLevels",
                column: "ClassLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSchools_SchoolId",
                table: "UserSchools",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkGroups_WorkGroupId",
                table: "UserWorkGroups",
                column: "WorkGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaperClassLevels");

            migrationBuilder.DropTable(
                name: "PaperKeywords");

            migrationBuilder.DropTable(
                name: "UserClassLevels");

            migrationBuilder.DropTable(
                name: "UserSchools");

            migrationBuilder.DropTable(
                name: "UserWorkGroups");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "ClassLevels");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "WorkGroups");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
