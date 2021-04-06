using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infastructure.Migrations
{
    public partial class Role_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("15a43493-e7c5-47db-94cc-8c0c3fc6e354"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("3a9a2eac-a55d-4f02-b62e-60d55c79bb67"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("440dac05-2caf-4b34-828f-4cd09d21136c"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("ad399898-1c84-4a63-9466-c993dbd17b49"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("c5ad0c38-4fda-40b9-bf2e-5f7bf06391b0"));

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Name", "Price", "Text" },
                values: new object[,]
                {
                    { new Guid("a15c37c5-112b-47d5-8530-8df56ff75270"), "Clean Code: A Handbook of Agile Software Craftsmanship 1st Edition", 6000m, null },
                    { new Guid("f6a4f1a4-efbc-4393-8f2e-a237a05863dd"), "Code Complete: A Practical Handbook of Software Construction, Second Edition 2nd Edition", 7000m, null },
                    { new Guid("983573a7-4ee0-420c-95ad-5b7fe5d369fa"), "Design Patterns: Elements of Reusable Object-Oriented Software 1st Edition", 11000m, null },
                    { new Guid("1692de3d-4c43-4381-9e75-8d4f1d8a75be"), "Getting Started with Spring Boot", 10000m, "Spring Boot cookbook" },
                    { new Guid("a8703384-b2e7-416a-b512-6e5db68862af"), "Building Web Applications with Visual Studio 2017", 7000m, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32ecbd5f-209e-4255-b234-81fa252b5765", "04bdbf94-0b8a-4b3f-8671-7b214bbc54e8", "Visitor", "VISITOR" },
                    { "7696d23b-c5fd-417f-b0b0-ae8eb9ab7a2f", "e98a8329-3d08-44d3-b654-b39297b8c770", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("1692de3d-4c43-4381-9e75-8d4f1d8a75be"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("983573a7-4ee0-420c-95ad-5b7fe5d369fa"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("a15c37c5-112b-47d5-8530-8df56ff75270"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("a8703384-b2e7-416a-b512-6e5db68862af"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("f6a4f1a4-efbc-4393-8f2e-a237a05863dd"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "32ecbd5f-209e-4255-b234-81fa252b5765");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "7696d23b-c5fd-417f-b0b0-ae8eb9ab7a2f");

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Name", "Price", "Text" },
                values: new object[,]
                {
                    { new Guid("c5ad0c38-4fda-40b9-bf2e-5f7bf06391b0"), "Clean Code: A Handbook of Agile Software Craftsmanship 1st Edition", 6000m, null },
                    { new Guid("3a9a2eac-a55d-4f02-b62e-60d55c79bb67"), "Code Complete: A Practical Handbook of Software Construction, Second Edition 2nd Edition", 7000m, null },
                    { new Guid("15a43493-e7c5-47db-94cc-8c0c3fc6e354"), "Design Patterns: Elements of Reusable Object-Oriented Software 1st Edition", 11000m, null },
                    { new Guid("440dac05-2caf-4b34-828f-4cd09d21136c"), "Getting Started with Spring Boot", 10000m, "Spring Boot cookbook" },
                    { new Guid("ad399898-1c84-4a63-9466-c993dbd17b49"), "Building Web Applications with Visual Studio 2017", 7000m, null }
                });
        }
    }
}
