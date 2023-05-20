using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingProject.Migrations
{
    public partial class changedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurentWeight",
                table: "Accounts",
                newName: "CurrentWeight");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentWeight",
                table: "Accounts",
                newName: "CurentWeight");
        }
    }
}
