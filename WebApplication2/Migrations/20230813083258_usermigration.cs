using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class usermigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "newCommentText",
                table: "NewsList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserModelId",
                table: "NewsList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsList_UserModelId",
                table: "NewsList",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsList_AspNetUsers_UserModelId",
                table: "NewsList",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsList_AspNetUsers_UserModelId",
                table: "NewsList");

            migrationBuilder.DropIndex(
                name: "IX_NewsList_UserModelId",
                table: "NewsList");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "NewsList");

            migrationBuilder.AlterColumn<string>(
                name: "newCommentText",
                table: "NewsList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
