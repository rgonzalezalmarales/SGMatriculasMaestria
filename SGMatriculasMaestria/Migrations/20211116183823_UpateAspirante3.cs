using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class UpateAspirante3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Aspirantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aspirantes_ProvinciaId",
                table: "Aspirantes",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aspirantes_Provincia_ProvinciaId",
                table: "Aspirantes",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aspirantes_Provincia_ProvinciaId",
                table: "Aspirantes");

            migrationBuilder.DropIndex(
                name: "IX_Aspirantes_ProvinciaId",
                table: "Aspirantes");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Aspirantes");
        }
    }
}
