using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRequests_AspNetUsers_RequesterId",
                table: "BorrowingRequests");
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRequests_AspNetUsers_ApproverId",
                table: "BorrowingRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f4cbe20-4815-4161-b181-38c8d8c66142"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5222f22e-ad25-4358-807c-3d38f840f21f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("57541f99-edb4-4209-bb2e-1d5c42c194cb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bcfa125-644d-402b-8887-d0f8a23fe27e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a0955c2b-a1fe-40b8-a790-0994aff65be5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a376d1e2-3324-411c-b813-05da5bed0846"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f0651a00-6580-4134-8e91-197de04cd52d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ffe5f910-60c3-4fc8-8334-9ac2eb96cf95"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("16dc795a-75e3-4562-a96d-4cd6ed8d686f"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/adventure.PNG", "Adventure" },
                    { new Guid("2965a498-8987-4434-987c-29a3228f2398"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/fantasy.PNG", "Fantasy" },
                    { new Guid("55e63b8f-508a-4373-a7df-6b0e8e63ab77"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/documentary.PNG", "Documentary" },
                    { new Guid("87956a44-c3b5-4ca4-94b3-8d15c9b504e8"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/drama.PNG", "Drama" },
                    { new Guid("8b0c5068-8f5d-4051-8b35-2a3953965226"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/crime.PNG", "Crime" },
                    { new Guid("99435dc9-565a-4331-a700-865067598849"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/action.PNG", "Action" },
                    { new Guid("9a4a2caa-366f-4aee-a49d-c3a9ede941b4"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/horror.PNG", "Horror" },
                    { new Guid("ca16a104-2137-4650-9d50-4f7aac7fc9ee"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/comedy.PNG", "Comedy" }
                });
        }
    }
}
