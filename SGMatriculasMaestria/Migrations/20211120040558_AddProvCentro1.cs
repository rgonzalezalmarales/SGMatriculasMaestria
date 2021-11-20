using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class AddProvCentro1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentroTrabajos_Provincias_ProvinciaId1",
                table: "CentroTrabajos");

            migrationBuilder.RenameColumn(
                name: "ProvinciaId1",
                table: "CentroTrabajos",
                newName: "ProvinciaId");

            migrationBuilder.RenameIndex(
                name: "IX_CentroTrabajos_ProvinciaId1",
                table: "CentroTrabajos",
                newName: "IX_CentroTrabajos_ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CentroTrabajos_Provincias_ProvinciaId",
                table: "CentroTrabajos",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentroTrabajos_Provincias_ProvinciaId",
                table: "CentroTrabajos");

            migrationBuilder.RenameColumn(
                name: "ProvinciaId",
                table: "CentroTrabajos",
                newName: "ProvinciaId1");

            migrationBuilder.RenameIndex(
                name: "IX_CentroTrabajos_ProvinciaId",
                table: "CentroTrabajos",
                newName: "IX_CentroTrabajos_ProvinciaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CentroTrabajos_Provincias_ProvinciaId1",
                table: "CentroTrabajos",
                column: "ProvinciaId1",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
