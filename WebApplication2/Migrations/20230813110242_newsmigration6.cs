using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class newsmigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsList_AspNetUsers_usermodelId",
                table: "NewsList");

            migrationBuilder.DropIndex(
                name: "IX_NewsList_usermodelId",
                table: "NewsList");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "NewsList");

            migrationBuilder.DropColumn(
                name: "usermodelId",
                table: "NewsList");

            migrationBuilder.CreateTable(
                name: "UserRead",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRead", x => new { x.UserId, x.NewsId });
                    table.ForeignKey(
                        name: "FK_UserRead_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRead_NewsList_NewsId",
                        column: x => x.NewsId,
                        principalTable: "NewsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRead_NewsId",
                table: "UserRead",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRead");

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "NewsList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "usermodelId",
                table: "NewsList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsList_usermodelId",
                table: "NewsList",
                column: "usermodelId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsList_AspNetUsers_usermodelId",
                table: "NewsList",
                column: "usermodelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
