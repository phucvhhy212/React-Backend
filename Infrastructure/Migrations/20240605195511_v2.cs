using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUserRequest");

            migrationBuilder.DropIndex(
                name: "IX_UserRequests_RequesterId",
                table: "UserRequests");

            migrationBuilder.DropIndex(
                name: "IX_BorrowingRequests_RequesterId",
                table: "BorrowingRequests");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("18ae141e-9815-4440-ac2f-3ee72e25bd72"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("53c90239-f021-4fad-99bb-3e7a8b586289"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("58058bd9-b351-485e-9ddd-053a5286bcc6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6693ec0a-b4d2-4b7e-bf2a-9c16f8879e58"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9148363b-223c-452d-9668-d9502f4fa72c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9259c051-7ee6-4a3b-978b-bdcb051f5292"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e4a03d5-af04-4385-87ce-c239b3b19eb7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bff981a0-c47c-479d-a2e6-47d0cbe6cbde"));

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "UserRequests",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_BookId",
                table: "UserRequests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_RequesterId",
                table: "UserRequests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRequests_RequesterId",
                table: "BorrowingRequests",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequests_Books_BookId",
                table: "UserRequests",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequests_Books_BookId",
                table: "UserRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserRequests_BookId",
                table: "UserRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserRequests_RequesterId",
                table: "UserRequests");

            migrationBuilder.DropIndex(
                name: "IX_BorrowingRequests_RequesterId",
                table: "BorrowingRequests");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6877095c-2b75-41d1-b552-abcf54f02cc2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c980b59-0d81-4e14-9750-e92225409bfd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6eca6d8f-e180-40fc-91b8-efb2f979d97e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f6209a1-039d-4d93-9d8b-4f69ae8d7ead"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("783828d9-a36a-412b-ba3f-d887f3684d0c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a71c3e8-05e9-4d6d-9086-e29e74ff7e87"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a8fa48dc-3754-468b-b918-6c2a29fae586"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b67d6e34-cb1d-48d4-9ea1-f8884ed7bf24"));

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserRequests");

            migrationBuilder.CreateTable(
                name: "BookUserRequest",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserRequestsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUserRequest", x => new { x.BooksId, x.UserRequestsId });
                    table.ForeignKey(
                        name: "FK_BookUserRequest_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUserRequest_UserRequests_UserRequestsId",
                        column: x => x.UserRequestsId,
                        principalTable: "UserRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("18ae141e-9815-4440-ac2f-3ee72e25bd72"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/documentary.PNG", "Documentary" },
                    { new Guid("53c90239-f021-4fad-99bb-3e7a8b586289"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/drama.PNG", "Drama" },
                    { new Guid("58058bd9-b351-485e-9ddd-053a5286bcc6"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/action.PNG", "Action" },
                    { new Guid("6693ec0a-b4d2-4b7e-bf2a-9c16f8879e58"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/crime.PNG", "Crime" },
                    { new Guid("9148363b-223c-452d-9668-d9502f4fa72c"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/horror.PNG", "Horror" },
                    { new Guid("9259c051-7ee6-4a3b-978b-bdcb051f5292"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/adventure.PNG", "Adventure" },
                    { new Guid("9e4a03d5-af04-4385-87ce-c239b3b19eb7"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/fantasy.PNG", "Fantasy" },
                    { new Guid("bff981a0-c47c-479d-a2e6-47d0cbe6cbde"), "https://nash-book.s3.ap-southeast-1.amazonaws.com/comedy.PNG", "Comedy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_RequesterId",
                table: "UserRequests",
                column: "RequesterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRequests_RequesterId",
                table: "BorrowingRequests",
                column: "RequesterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookUserRequest_UserRequestsId",
                table: "BookUserRequest",
                column: "UserRequestsId");
        }
    }
}
