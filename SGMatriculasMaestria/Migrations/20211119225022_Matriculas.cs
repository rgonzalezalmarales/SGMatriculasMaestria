using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class Matriculas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aspirantes_AspiranteCI",
                table: "Matricula");

            migrationBuilder.AlterColumn<int>(
                name: "AspiranteId",
                table: "Matricula",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AspiranteCI",
                table: "Matricula",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "Matricula",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "CI",
                table: "Aspirantes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aspirantes_AspiranteCI",
                table: "Matricula",
                column: "AspiranteCI",
                principalTable: "Aspirantes",
                principalColumn: "CI",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aspirantes_AspiranteCI",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "Matricula");

            migrationBuilder.AlterColumn<int>(
                name: "AspiranteId",
                table: "Matricula",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AspiranteCI",
                table: "Matricula",
                type: "nvarchar(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CI",
                table: "Aspirantes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aspirantes_AspiranteCI",
                table: "Matricula",
                column: "AspiranteCI",
                principalTable: "Aspirantes",
                principalColumn: "CI",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
