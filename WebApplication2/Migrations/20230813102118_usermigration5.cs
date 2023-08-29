using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class usermigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsList_AspNetUsers_UserModelId",
                table: "NewsList");

            migrationBuilder.RenameColumn(
                name: "UserModelId",
                table: "NewsList",
                newName: "usermodelId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsList_UserModelId",
                table: "NewsList",
                newName: "IX_NewsList_usermodelId");

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "NewsList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsList_AspNetUsers_usermodelId",
                table: "NewsList",
                column: "usermodelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsList_AspNetUsers_usermodelId",
                table: "NewsList");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "NewsList");

            migrationBuilder.RenameColumn(
                name: "usermodelId",
                table: "NewsList",
                newName: "UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsList_usermodelId",
                table: "NewsList",
                newName: "IX_NewsList_UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsList_AspNetUsers_UserModelId",
                table: "NewsList",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
