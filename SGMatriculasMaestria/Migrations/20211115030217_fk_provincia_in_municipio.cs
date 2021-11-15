using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class fk_provincia_in_municipio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Provincia_ProvinciaId",
                table: "Municipios");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Municipios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Provincia_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Provincia_ProvinciaId",
                table: "Municipios");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Municipios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Provincia_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
