using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
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
            //migrationBuilder.DropIndex(
            //    name: "IX_BorrowingRequests_RequesterId",
            //    table: "BorrowingRequests");
            //migrationBuilder.CreateIndex(
            //    name: "IX_BorrowingRequests_RequesterId",
            //    column: "RequesterId",
            //    table: "BorrowingRequests",
            //    unique:false);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_BorrowingRequests_AspNetUsers_ApproverId",
            //    table: "BorrowingRequests",
            //    column: "ApproverId",
            //    principalTable: "Books",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_BorrowingRequests_AspNetUsers_RequesterId",
            //    table: "BorrowingRequests",
            //    column: "RequesterId",
            //    principalTable: "Books",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("16dc795a-75e3-4562-a96d-4cd6ed8d686f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2965a498-8987-4434-987c-29a3228f2398"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55e63b8f-508a-4373-a7df-6b0e8e63ab77"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("87956a44-c3b5-4ca4-94b3-8d15c9b504e8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b0c5068-8f5d-4051-8b35-2a3953965226"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("99435dc9-565a-4331-a700-865067598849"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a4a2caa-366f-4aee-a49d-c3a9ede941b4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ca16a104-2137-4650-9d50-4f7aac7fc9ee"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("6877095c-2b75-41d1-b552-abcf54f02cc2"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/documentary.PNG", "Documentary" },
                    { new Guid("6c980b59-0d81-4e14-9750-e92225409bfd"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/adventure.PNG", "Adventure" },
                    { new Guid("6eca6d8f-e180-40fc-91b8-efb2f979d97e"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/drama.PNG", "Drama" },
                    { new Guid("6f6209a1-039d-4d93-9d8b-4f69ae8d7ead"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/crime.PNG", "Crime" },
                    { new Guid("783828d9-a36a-412b-ba3f-d887f3684d0c"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/action.PNG", "Action" },
                    { new Guid("9a71c3e8-05e9-4d6d-9086-e29e74ff7e87"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/fantasy.PNG", "Fantasy" },
                    { new Guid("a8fa48dc-3754-468b-b918-6c2a29fae586"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/comedy.PNG", "Comedy" },
                    { new Guid("b67d6e34-cb1d-48d4-9ea1-f8884ed7bf24"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/horror.PNG", "Horror" }
                });
        }
    }
}
