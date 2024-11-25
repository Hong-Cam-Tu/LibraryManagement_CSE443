using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForBooksandCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Pdf",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Books",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(637), new DateTime(2024, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(655), new DateTime(2024, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(657), new DateTime(2024, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(658) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Avatar", "CreatedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Programming", null },
                    { 2, null, null, null, null, "Fiction", null },
                    { 3, null, null, null, null, "Science fiction", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "AvailableCopies", "Avatar", "BookCode", "CategoryId", "CreatedDate", "Description", "IsActive", "Pdf", "PublishedYear", "Publisher", "Title", "TotalCopies" },
                values: new object[,]
                {
                    { 1, 0, 7, null, "CSPROG001", 1, new DateTime(2024, 5, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(852), "An introductory book on C# programming.", null, null, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew Troelsen", "Learning C#", 10 },
                    { 2, 0, 5, null, "ASP001", 1, new DateTime(2024, 7, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(862), "A comprehensive guide to mastering ASP.NET Core.", null, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Dev Publishers", "Mastering ASP.NET Core", 8 },
                    { 3, 0, 10, null, "FIC001", 2, new DateTime(1927, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(865), "A classic novel set in the Roaring Twenties.", null, null, new DateTime(1925, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Literary Classics", "The Great Gatsby", 15 },
                    { 4, 0, 6, null, "FIC002", 2, new DateTime(1961, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(868), "A novel about racial injustice in the American South.", null, null, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper & Brothers", "To Kill a Mockingbird", 12 },
                    { 5, 0, 15, null, "SCI001", 3, new DateTime(1966, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(870), "A science fiction novel set on the desert planet Arrakis.", null, null, new DateTime(1965, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sci-Fi Press", "Dune", 20 },
                    { 6, 0, 14, null, "SCI002", 3, new DateTime(1952, 11, 5, 9, 38, 44, 191, DateTimeKind.Local).AddTicks(872), "A novel about the decline and fall of a Galactic Empire.", null, null, new DateTime(1951, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Galaxy Publications", "Foundation", 18 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pdf",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1815), new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1833) });

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1834), new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1835) });

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1837), new DateTime(2024, 11, 3, 14, 56, 58, 167, DateTimeKind.Local).AddTicks(1837) });
        }
    }
}
