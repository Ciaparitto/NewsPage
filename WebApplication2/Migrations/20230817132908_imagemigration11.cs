using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class imagemigration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsList_NewsId",
                table: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_NewsList_Id",
                table: "Image",
                column: "NewsId",
                principalTable: "NewsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsList_NewsId",
                table: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_NewsList_Id",
                table: "Image",
                column: "NewsId",
                principalTable: "NewsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
