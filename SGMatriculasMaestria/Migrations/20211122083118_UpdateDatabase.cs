using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "SecretarioPostgrados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "SecretarioPostgrados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "Provincias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "Provincias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "Paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "Paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "Municipios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "Municipios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "Maestrias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "Maestrias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "Facultades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "Facultades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "EspecGraduados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "EspecGraduados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "Ces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "Ces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Ces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "CentroTrabajos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "CentroTrabajos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "CategDocentes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "CategDocentes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creatat",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiat",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Ces_ProvinciaId",
                table: "Ces",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ces_Provincias_ProvinciaId",
                table: "Ces",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ces_Provincias_ProvinciaId",
                table: "Ces");

            migrationBuilder.DropIndex(
                name: "IX_Ces_ProvinciaId",
                table: "Ces");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "SecretarioPostgrados");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "SecretarioPostgrados");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "Provincias");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "Provincias");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "Municipios");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "Municipios");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "Maestrias");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "Maestrias");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "Facultades");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "Facultades");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "EspecGraduados");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "EspecGraduados");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "Ces");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "Ces");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Ces");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "CentroTrabajos");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "CentroTrabajos");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "CategDocentes");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "CategDocentes");

            migrationBuilder.DropColumn(
                name: "Creatat",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Modifiat",
                table: "AspNetUsers");
        }
    }
}
