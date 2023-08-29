using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class imagemigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Image",
                newName: "id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Image",
                newName: "Id");

           
        }
    }
}
