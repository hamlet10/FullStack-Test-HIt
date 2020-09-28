using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Persistence.Migrations
{
    public partial class someModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_MyUrls_MyUrlId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_MyUrlId",
                table: "Visitors");

            migrationBuilder.AddColumn<int>(
                name: "VisitorsId",
                table: "MyUrls",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyUrls_VisitorsId",
                table: "MyUrls",
                column: "VisitorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyUrls_Visitors_VisitorsId",
                table: "MyUrls",
                column: "VisitorsId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUrls_Visitors_VisitorsId",
                table: "MyUrls");

            migrationBuilder.DropIndex(
                name: "IX_MyUrls_VisitorsId",
                table: "MyUrls");

            migrationBuilder.DropColumn(
                name: "VisitorsId",
                table: "MyUrls");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_MyUrlId",
                table: "Visitors",
                column: "MyUrlId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_MyUrls_MyUrlId",
                table: "Visitors",
                column: "MyUrlId",
                principalTable: "MyUrls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
