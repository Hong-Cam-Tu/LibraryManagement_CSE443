using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class addImageCarousel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carousels",
                columns: new[] { "CarouselId", "CreatedDate", "Description", "ImageUrl", "IsActive", "LinkUrl", "Order", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1815), "Image1", "/carousel_images/carousel_1.webp", true, null, 1, "Image 1", new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1833) },
                    { 2, new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1834), "Image2", "/carousel_images/carousel_2.webp", true, null, 2, "Image 2", new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1835) },
                    { 3, new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1837), "Image3", "/carousel_images/carousel_3.webp", true, null, 3, "Image 3", new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1837) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 3);
        }
    }
}
