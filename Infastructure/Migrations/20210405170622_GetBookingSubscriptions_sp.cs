using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infastructure.Migrations
{
    public partial class GetBookingSubscriptions_sp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC dbo.GetSubscription
(
 @UserId VARCHAR(450) = NULL
)
AS
BEGIN
SELECT B.*,IIF(BS.Id IS NULL, 'No','Yes') Subscribed
FROM Book B LEFT JOIN 
                     (
					  SELECT BB.Id,BB.BookId
					  FROM BookSubscription BB
					  WHERE UserId = @UserId 
					 ) BS ON B.Id = BS.BookId
END
GO");
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
                    { new Guid("35a93cbd-20bb-4521-a43e-8df6047e9551"), "Clean Code: A Handbook of Agile Software Craftsmanship 1st Edition", 6000m, null },
                    { new Guid("ee358b35-2acd-48fd-b435-33b257a4733a"), "Code Complete: A Practical Handbook of Software Construction, Second Edition 2nd Edition", 7000m, null },
                    { new Guid("050817fc-83d1-4fd6-a1e1-3dabbb1b46ab"), "Design Patterns: Elements of Reusable Object-Oriented Software 1st Edition", 11000m, null },
                    { new Guid("bdd7f4e3-2926-46b9-a44f-637376777bf1"), "Getting Started with Spring Boot", 10000m, "Spring Boot cookbook" },
                    { new Guid("13dddc48-340e-47fd-99c9-9681ff4f8b9e"), "Building Web Applications with Visual Studio 2017", 7000m, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04ecc078-ce0d-4282-96a7-9dc5ce10c7f2", "0d5fd67c-5633-483f-8e0b-921d61bb3322", "Visitor", "VISITOR" },
                    { "aad1faef-7c02-4e58-8231-432943e67e70", "8b402b49-8505-491c-b133-b01b65cacc27", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC dbo.GetSubscription");
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("050817fc-83d1-4fd6-a1e1-3dabbb1b46ab"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("13dddc48-340e-47fd-99c9-9681ff4f8b9e"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("35a93cbd-20bb-4521-a43e-8df6047e9551"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("bdd7f4e3-2926-46b9-a44f-637376777bf1"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("ee358b35-2acd-48fd-b435-33b257a4733a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "04ecc078-ce0d-4282-96a7-9dc5ce10c7f2");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "aad1faef-7c02-4e58-8231-432943e67e70");

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
    }
}
