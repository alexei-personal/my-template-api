using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DocumentSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryColor",
                table: "Document",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.InsertData(
                table: "Document",
                columns: new[] { "Id", "Code", "Created", "CreatedBy", "IsActive", "LastModified", "LastModifiedBy", "Title" },
                values: new object[,]
                {
                    { -10, "F-73848", new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", false, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Exploring new galaxies" },
                    { -9, "E-94748", new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", true, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Planning a trip to the moon" },
                    { -8, "F-65487", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", false, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Planning a vacation" },
                    { -7, "E-34569", new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", true, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Organizing a party" },
                    { -6, "F-98546", new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", true, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "Planning a vacation" },
                    { -5, "E-11223", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", true, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Organizing a trip" },
                    { -4, "D-85738", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", true, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Traveling to Hawaii" },
                    { -3, "C-94857", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", false, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Buying a car" },
                    { -2, "B-93847", new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", true, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "Planning a trip" },
                    { -1, "A-93489", new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", true, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "Buying some stuff" }
                });

            migrationBuilder.InsertData(
                table: "DocumentDetail",
                columns: new[] { "Id", "Created", "CreatedBy", "DocumentId", "LastModified", "LastModifiedBy", "Priority", "Solved", "Text" },
                values: new object[,]
                {
                    { -102, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -10, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Gather supplies" },
                    { -101, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -10, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Find a spaceship" },
                    { -92, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -9, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Find a good hotel" },
                    { -91, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -9, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Book a flight" },
                    { -82, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -8, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Book flights" },
                    { -81, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -8, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Research destinations" },
                    { -72, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -7, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Prepare guest list" },
                    { -71, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -7, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Find a venue" },
                    { -62, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -6, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Book flights" },
                    { -61, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -6, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Research destinations" },
                    { -52, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -5, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Find accommodation" },
                    { -51, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -5, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Book flights" },
                    { -42, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -4, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Book accommodation" },
                    { -41, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -4, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Book flights" },
                    { -32, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -3, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Arrange test drive" },
                    { -31, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -3, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Compare prices" },
                    { -22, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -2, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 1, false, "Find accommodations" },
                    { -21, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester Y", -2, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester Y", 3, false, "Book flight tickets" },
                    { -12, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me", -2, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", 2, false, "Talk to stakeholders" },
                    { -11, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", -1, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester X", 3, false, "Getting offers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -102);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -101);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -92);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -91);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -82);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -81);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -72);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -71);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -62);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -61);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -52);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -51);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -42);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -41);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -32);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -31);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "DocumentDetail",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryColor",
                table: "Document",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);
        }
    }
}
