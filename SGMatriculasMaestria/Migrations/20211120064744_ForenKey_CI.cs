using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class ForenKey_CI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspiranteId",
                table: "Matricula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspiranteId",
                table: "Matricula",
                type: "int",
                nullable: true);
        }
    }
}
