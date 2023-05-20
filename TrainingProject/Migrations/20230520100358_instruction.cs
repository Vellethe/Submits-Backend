using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingProject.Migrations
{
    public partial class instruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurentWeight",
                table: "Accounts",
                newName: "CurrentWeight");

            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "CurrentWeight",
                table: "Accounts",
                newName: "CurentWeight");
        }
    }
}
