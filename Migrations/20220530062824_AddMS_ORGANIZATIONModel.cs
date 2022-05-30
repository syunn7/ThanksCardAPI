﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ThanksCardAPI.Migrations
{
    public partial class AddMS_ORGANIZATIONModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ThanksCards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "ThanksCards",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "ThanksCards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "MS_ORGANIZATIONId",
                table: "Departments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ORGANIZATIONs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ORGANIZATION_CD = table.Column<int>(type: "integer", nullable: false),
                    ORGANIZATION_NAME = table.Column<string>(type: "text", nullable: true),
                    PARENT_ID = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORGANIZATIONs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONs_Departments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPOLOYEEs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EMPLOYEE_CD = table.Column<string>(type: "text", nullable: false),
                    EMPLOYEE_NAME = table.Column<string>(type: "text", nullable: false),
                    FURIGANA = table.Column<string>(type: "text", nullable: false),
                    PASSWORD = table.Column<string>(type: "text", nullable: false),
                    ORGANIZATION_ID = table.Column<long>(type: "bigint", nullable: true),
                    ORGANIZATIONId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPOLOYEEs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPOLOYEEs_ORGANIZATIONs_ORGANIZATIONId",
                        column: x => x.ORGANIZATIONId,
                        principalTable: "ORGANIZATIONs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MS_ORGANIZATIONId",
                table: "Departments",
                column: "MS_ORGANIZATIONId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPOLOYEEs_ORGANIZATIONId",
                table: "EMPOLOYEEs",
                column: "ORGANIZATIONId");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONs_ParentId",
                table: "ORGANIZATIONs",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_ORGANIZATIONs_MS_ORGANIZATIONId",
                table: "Departments",
                column: "MS_ORGANIZATIONId",
                principalTable: "ORGANIZATIONs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_ORGANIZATIONs_MS_ORGANIZATIONId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "EMPOLOYEEs");

            migrationBuilder.DropTable(
                name: "ORGANIZATIONs");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MS_ORGANIZATIONId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "MS_ORGANIZATIONId",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ThanksCards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "ThanksCards",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "ThanksCards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
