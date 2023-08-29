using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class ReadNewsMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRead_AspNetUsers_UserId",
                table: "UserRead");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRead_NewsList_NewsId",
                table: "UserRead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRead",
                table: "UserRead");

            migrationBuilder.RenameTable(
                name: "UserRead",
                newName: "UserReads");

            migrationBuilder.RenameIndex(
                name: "IX_UserRead_NewsId",
                table: "UserReads",
                newName: "IX_UserReads_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReads",
                table: "UserReads",
                columns: new[] { "UserId", "NewsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserReads_AspNetUsers_UserId",
                table: "UserReads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReads_NewsList_NewsId",
                table: "UserReads",
                column: "NewsId",
                principalTable: "NewsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReads_AspNetUsers_UserId",
                table: "UserReads");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReads_NewsList_NewsId",
                table: "UserReads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReads",
                table: "UserReads");

            migrationBuilder.RenameTable(
                name: "UserReads",
                newName: "UserRead");

            migrationBuilder.RenameIndex(
                name: "IX_UserReads_NewsId",
                table: "UserRead",
                newName: "IX_UserRead_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRead",
                table: "UserRead",
                columns: new[] { "UserId", "NewsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRead_AspNetUsers_UserId",
                table: "UserRead",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRead_NewsList_NewsId",
                table: "UserRead",
                column: "NewsId",
                principalTable: "NewsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
