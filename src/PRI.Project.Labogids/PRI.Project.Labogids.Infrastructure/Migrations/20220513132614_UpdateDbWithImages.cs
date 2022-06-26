using Microsoft.EntityFrameworkCore.Migrations;

namespace PRI.Project.Labogids.Infrastructure.Migrations
{
    public partial class UpdateDbWithImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Specimens",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "edta.jpg");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "edta.jpg");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "serum.jpg");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "citraat.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Specimens",
                newName: "ImgUrl");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: null);
        }
    }
}
