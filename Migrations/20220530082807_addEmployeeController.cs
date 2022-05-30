using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanksCardAPI.Migrations
{
    public partial class addEmployeeController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_MS_ORGANIZATION_ORGANIZATIONId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ORGANIZATION_ID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "Employees",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "ORGANIZATIONId",
                table: "Employees",
                newName: "OrganizationId");

            migrationBuilder.RenameColumn(
                name: "FURIGANA",
                table: "Employees",
                newName: "Furigana");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEE_NAME",
                table: "Employees",
                newName: "Employeename");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEE_CD",
                table: "Employees",
                newName: "Employeecd");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ORGANIZATIONId",
                table: "Employees",
                newName: "IX_Employees_OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_MS_ORGANIZATION_OrganizationId",
                table: "Employees",
                column: "OrganizationId",
                principalTable: "MS_ORGANIZATION",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_MS_ORGANIZATION_OrganizationId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employees",
                newName: "PASSWORD");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Employees",
                newName: "ORGANIZATIONId");

            migrationBuilder.RenameColumn(
                name: "Furigana",
                table: "Employees",
                newName: "FURIGANA");

            migrationBuilder.RenameColumn(
                name: "Employeename",
                table: "Employees",
                newName: "EMPLOYEE_NAME");

            migrationBuilder.RenameColumn(
                name: "Employeecd",
                table: "Employees",
                newName: "EMPLOYEE_CD");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_OrganizationId",
                table: "Employees",
                newName: "IX_Employees_ORGANIZATIONId");

            migrationBuilder.AddColumn<long>(
                name: "ORGANIZATION_ID",
                table: "Employees",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_MS_ORGANIZATION_ORGANIZATIONId",
                table: "Employees",
                column: "ORGANIZATIONId",
                principalTable: "MS_ORGANIZATION",
                principalColumn: "Id");
        }
    }
}
