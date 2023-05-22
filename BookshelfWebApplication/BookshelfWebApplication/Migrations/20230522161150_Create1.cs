using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookshelfWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class Create1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorPublicationss_Authors_AuthorId1",
                table: "AuthorPublicationss");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorPublicationss_Publications_BookId1",
                table: "AuthorPublicationss");

            migrationBuilder.DropIndex(
                name: "IX_AuthorPublicationss_AuthorId1",
                table: "AuthorPublicationss");

            migrationBuilder.DropIndex(
                name: "IX_AuthorPublicationss_BookId1",
                table: "AuthorPublicationss");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "AuthorPublicationss");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "AuthorPublicationss");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Publications",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "AuthorPublicationss",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "AuthorPublicationss",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublicationss_AuthorId",
                table: "AuthorPublicationss",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublicationss_PublicationId",
                table: "AuthorPublicationss",
                column: "PublicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorPublicationss_Authors_AuthorId",
                table: "AuthorPublicationss",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorPublicationss_Publications_PublicationId",
                table: "AuthorPublicationss",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorPublicationss_Authors_AuthorId",
                table: "AuthorPublicationss");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorPublicationss_Publications_PublicationId",
                table: "AuthorPublicationss");

            migrationBuilder.DropIndex(
                name: "IX_AuthorPublicationss_AuthorId",
                table: "AuthorPublicationss");

            migrationBuilder.DropIndex(
                name: "IX_AuthorPublicationss_PublicationId",
                table: "AuthorPublicationss");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PublicationId",
                table: "AuthorPublicationss",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "AuthorPublicationss",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId1",
                table: "AuthorPublicationss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "AuthorPublicationss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublicationss_AuthorId1",
                table: "AuthorPublicationss",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublicationss_BookId1",
                table: "AuthorPublicationss",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorPublicationss_Authors_AuthorId1",
                table: "AuthorPublicationss",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorPublicationss_Publications_BookId1",
                table: "AuthorPublicationss",
                column: "BookId1",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
