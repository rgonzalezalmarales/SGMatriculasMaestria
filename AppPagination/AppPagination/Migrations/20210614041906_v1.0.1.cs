using Microsoft.EntityFrameworkCore.Migrations;
using AppPagination.Data;

namespace AppPagination.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            DbInitializer.Inicialize(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
