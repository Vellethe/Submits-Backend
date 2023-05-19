using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingProject.Migrations
{
    public partial class AccountData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountData_Accounts_UserId",
                table: "AccountData");

            migrationBuilder.DropColumn(
                name: "CurrentWeight",
                table: "AccountData");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AccountData");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AccountData",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountData_UserId",
                table: "AccountData",
                newName: "IX_AccountData_AccountId");

            migrationBuilder.AddColumn<int>(
                name: "CurrentWeight",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountData_Accounts_AccountId",
                table: "AccountData",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountData_Accounts_AccountId",
                table: "AccountData");

            migrationBuilder.DropColumn(
                name: "CurrentWeight",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AccountData",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountData_AccountId",
                table: "AccountData",
                newName: "IX_AccountData_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CurrentWeight",
                table: "AccountData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "AccountData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountData_Accounts_UserId",
                table: "AccountData",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
