using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class segundoapellido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "Aspirantes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "Aspirantes");
        }
    }
}
