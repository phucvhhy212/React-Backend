using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRequests_AspNetUsers_ApproverId",
                table: "BorrowingRequests",
                column: "ApproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRequests_AspNetUsers_RequesterId",
                table: "BorrowingRequests",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a3c8425-ba87-48a5-8357-f6855bc9f3b7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1186492e-eb44-41d8-b0d4-7a4b16b30bb9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44b2f85d-1d5e-4e2f-8eaf-833d4bf98d4e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f8bd693-526e-424e-af92-39dee7c4505f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("864e2c82-996f-45c4-b58b-c50abaf09191"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("96a24a25-90ca-4ebc-b816-155cb238df22"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a250402-af3c-4601-bcfe-64783e48a217"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f9b5fcbe-e557-44c0-b8ec-4aaf1774462e"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("1f4cbe20-4815-4161-b181-38c8d8c66142"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/crime.PNG", "Crime" },
                    { new Guid("5222f22e-ad25-4358-807c-3d38f840f21f"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/fantasy.PNG", "Fantasy" },
                    { new Guid("57541f99-edb4-4209-bb2e-1d5c42c194cb"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/horror.PNG", "Horror" },
                    { new Guid("8bcfa125-644d-402b-8887-d0f8a23fe27e"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/adventure.PNG", "Adventure" },
                    { new Guid("a0955c2b-a1fe-40b8-a790-0994aff65be5"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/comedy.PNG", "Comedy" },
                    { new Guid("a376d1e2-3324-411c-b813-05da5bed0846"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/documentary.PNG", "Documentary" },
                    { new Guid("f0651a00-6580-4134-8e91-197de04cd52d"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/action.PNG", "Action" },
                    { new Guid("ffe5f910-60c3-4fc8-8334-9ac2eb96cf95"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/drama.PNG", "Drama" }
                });
        }
    }
}
