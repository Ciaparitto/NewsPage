using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class Imagemigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsList_NewsId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_Image_NewsId",
                table: "Image",
                newName: "IX_Image_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_NewsList_NewsId",
                table: "Image",
                column: "NewsId",
                principalTable: "NewsList",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsList_NewsId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_Image_NewsId",
                table: "Image",
                newName: "IX_Image_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_NewsList_NewsId",
                table: "Image",
                column: "NewsId",
                principalTable: "NewsList",
                principalColumn: "Id");
        }
    }
}
