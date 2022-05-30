using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanksCardAPI.Migrations
{
    public partial class AddMS_ORGANIZATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_ORGANIZATIONs_MS_ORGANIZATIONId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_ORGANIZATIONs_Departments_ParentId",
                table: "ORGANIZATIONs");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MS_ORGANIZATIONId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "PARENT_ID",
                table: "ORGANIZATIONs");

            migrationBuilder.DropColumn(
                name: "MS_ORGANIZATIONId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "ORGANIZATION_NAME",
                table: "ORGANIZATIONs",
                newName: "Organiztionname");

            migrationBuilder.RenameColumn(
                name: "ORGANIZATION_CD",
                table: "ORGANIZATIONs",
                newName: "Organiztioncd");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "ORGANIZATIONs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ORGANIZATIONs_ORGANIZATIONs_ParentId",
                table: "ORGANIZATIONs",
                column: "ParentId",
                principalTable: "ORGANIZATIONs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORGANIZATIONs_ORGANIZATIONs_ParentId",
                table: "ORGANIZATIONs");

            migrationBuilder.RenameColumn(
                name: "Organiztionname",
                table: "ORGANIZATIONs",
                newName: "ORGANIZATION_NAME");

            migrationBuilder.RenameColumn(
                name: "Organiztioncd",
                table: "ORGANIZATIONs",
                newName: "ORGANIZATION_CD");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "ORGANIZATIONs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PARENT_ID",
                table: "ORGANIZATIONs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MS_ORGANIZATIONId",
                table: "Departments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MS_ORGANIZATIONId",
                table: "Departments",
                column: "MS_ORGANIZATIONId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_ORGANIZATIONs_MS_ORGANIZATIONId",
                table: "Departments",
                column: "MS_ORGANIZATIONId",
                principalTable: "ORGANIZATIONs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ORGANIZATIONs_Departments_ParentId",
                table: "ORGANIZATIONs",
                column: "ParentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
