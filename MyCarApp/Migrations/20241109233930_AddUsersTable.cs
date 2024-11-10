using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCarApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "ImagePath" },
                values: new object[] { 1, "Luxe compact model", "path/to/image1.jpg" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImagePath" },
                values: new object[] { 1, "Sportieve SUV", "path/to/image2.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "ImagePath" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImagePath" },
                values: new object[] { null, null, null });
        }
    }
}
