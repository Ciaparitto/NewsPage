using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class comment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "newsId",
                table: "Comments",
                newName: "NewsId");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "creator");

            migrationBuilder.AddColumn<string>(
                name: "CommentText",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_NewsList_NewsId",
                table: "Comments",
                column: "NewsId",
                principalTable: "NewsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_NewsList_NewsId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_NewsId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentText",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "Comments",
                newName: "newsId");

            migrationBuilder.RenameColumn(
                name: "creator",
                table: "Comments",
                newName: "Content");
        }
    }
}
