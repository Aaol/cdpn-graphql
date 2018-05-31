using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksApiDbLib.Migrations
{
    public partial class RequiredFieldsCancel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Books",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Books",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
