using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class att11111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Books_PreviousBookId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PreviousBookId",
                table: "Books",
                newName: "PreviousBookBookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PreviousBookId",
                table: "Books",
                newName: "IX_Books_PreviousBookBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Books_PreviousBookBookId",
                table: "Books",
                column: "PreviousBookBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Books_PreviousBookBookId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PreviousBookBookId",
                table: "Books",
                newName: "PreviousBookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PreviousBookBookId",
                table: "Books",
                newName: "IX_Books_PreviousBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Books_PreviousBookId",
                table: "Books",
                column: "PreviousBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
