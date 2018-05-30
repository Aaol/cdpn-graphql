using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksApiDbLib.Migrations
{
    public partial class BooksCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Author_AuthorIdentifier",
                table: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Author_AuthorIdentifier",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "AuthorIdentifier",
                table: "Author");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AuthorIdentifier",
                table: "Author",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_AuthorIdentifier",
                table: "Author",
                column: "AuthorIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Author_AuthorIdentifier",
                table: "Author",
                column: "AuthorIdentifier",
                principalTable: "Author",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
