using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanksCardAPI.Migrations
{
    public partial class addMS_EMPLOYEEController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPOLOYEEs_MS_ORGANIZATION_ORGANIZATIONId",
                table: "EMPOLOYEEs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EMPOLOYEEs",
                table: "EMPOLOYEEs");

            migrationBuilder.RenameTable(
                name: "EMPOLOYEEs",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_EMPOLOYEEs_ORGANIZATIONId",
                table: "Employees",
                newName: "IX_Employees_ORGANIZATIONId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_MS_ORGANIZATION_ORGANIZATIONId",
                table: "Employees",
                column: "ORGANIZATIONId",
                principalTable: "MS_ORGANIZATION",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_MS_ORGANIZATION_ORGANIZATIONId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "EMPOLOYEEs");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ORGANIZATIONId",
                table: "EMPOLOYEEs",
                newName: "IX_EMPOLOYEEs_ORGANIZATIONId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EMPOLOYEEs",
                table: "EMPOLOYEEs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EMPOLOYEEs_MS_ORGANIZATION_ORGANIZATIONId",
                table: "EMPOLOYEEs",
                column: "ORGANIZATIONId",
                principalTable: "MS_ORGANIZATION",
                principalColumn: "Id");
        }
    }
}
