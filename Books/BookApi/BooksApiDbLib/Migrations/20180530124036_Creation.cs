using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksApiDbLib.Migrations
{
    public partial class Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Identifier = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    AuthorIdentifier = table.Column<long>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Identifier = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorIdentifier",
                        column: x => x.AuthorIdentifier,
                        principalTable: "Authors",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookComments",
                columns: table => new
                {
                    Comment = table.Column<string>(nullable: false),
                    BookIdentifier = table.Column<long>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    Identifier = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookComment", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_BookComments_Books_BookIdentifier",
                        column: x => x.BookIdentifier,
                        principalTable: "Books",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookComments_BookIdentifier",
                table: "BookComments",
                column: "BookIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorIdentifier",
                table: "Books",
                column: "AuthorIdentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookComments");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
