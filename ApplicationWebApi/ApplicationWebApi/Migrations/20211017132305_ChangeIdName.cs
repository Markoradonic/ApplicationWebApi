using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationWebApi.Migrations
{
    public partial class ChangeIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Persons",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "PersonId");
        }
    }
}
