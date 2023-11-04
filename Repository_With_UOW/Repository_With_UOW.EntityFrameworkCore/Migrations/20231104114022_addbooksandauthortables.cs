using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_With_UOW.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addbooksandauthortables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepositoryWithUOW.Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryWithUOW.Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryWithUOW.Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryWithUOW.Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryWithUOW.Book_RepositoryWithUOW.Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "RepositoryWithUOW.Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryWithUOW.Book_AuthorId",
                table: "RepositoryWithUOW.Book",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepositoryWithUOW.Book");

            migrationBuilder.DropTable(
                name: "RepositoryWithUOW.Author");
        }
    }
}
