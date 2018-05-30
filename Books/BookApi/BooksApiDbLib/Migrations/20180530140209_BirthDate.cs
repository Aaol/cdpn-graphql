using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksApiDbLib.Migrations
{
    public partial class BirthDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookComments_Books_BookIdentifier",
                table: "BookComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorIdentifier",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorIdentifier",
                table: "Book",
                newName: "IX_Book_AuthorIdentifier");

            migrationBuilder.AddColumn<long>(
                name: "AuthorIdentifier",
                table: "Author",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorIdentifier",
                table: "Book",
                column: "AuthorIdentifier",
                principalTable: "Author",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookComments_Author_BookIdentifier",
                table: "BookComments",
                column: "BookIdentifier",
                principalTable: "Author",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Author_AuthorIdentifier",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorIdentifier",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookComments_Author_BookIdentifier",
                table: "BookComments");

            migrationBuilder.DropIndex(
                name: "IX_Author_AuthorIdentifier",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "AuthorIdentifier",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorIdentifier",
                table: "Books",
                newName: "IX_Books_AuthorIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_BookComments_Books_BookIdentifier",
                table: "BookComments",
                column: "BookIdentifier",
                principalTable: "Books",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorIdentifier",
                table: "Books",
                column: "AuthorIdentifier",
                principalTable: "Authors",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
