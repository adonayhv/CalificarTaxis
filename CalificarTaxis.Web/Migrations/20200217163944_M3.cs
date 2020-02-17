using Microsoft.EntityFrameworkCore.Migrations;

namespace CalificarTaxis.Web.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_taxiEntities_Plaque",
                table: "taxiEntities",
                column: "Plaque",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_taxiEntities_Plaque",
                table: "taxiEntities");
        }
    }
}
