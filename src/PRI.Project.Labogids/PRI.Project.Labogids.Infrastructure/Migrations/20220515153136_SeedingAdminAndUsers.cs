using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRI.Project.Labogids.Infrastructure.Migrations
{
    public partial class SeedingAdminAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "Spoorwegstraat 4", "Brugge", "42d56bc5-a5de-4191-9f8a-abe225ef8888", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin.one@labguide.com", true, "Admin", "One", false, null, "ADMIN.ONE@LABGUIDE.COM", "ADMIN.ONE@LABGUIDE.COM", "AQAAAAEAACcQAAAAEAKI3maOZ/x8r1jBUcSGCVzIMjxTmwl6ro3L0RMsF+rJvWK6q+Rw7MYZX6ZJveqKsQ==", null, false, 8000, "0a007954-d51f-4fd1-9a78-06ccd4ca6725", false, "admin.one@labguide.com" },
                    { "2", 0, "Spoorwegstraat 4", "Brugge", "a6943dd4-609d-48cd-924d-d59a42463d6c", new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin.two@labguide.com", true, "Admin", "Two", false, null, "ADMIN.TWO@LABGUIDE.COM", "ADMIN.TWO@LABGUIDE.COM", "AQAAAAEAACcQAAAAELlZsPrYPI4IhintOshkL2i85fKewWMgkOh2YbDw9YDWPLEtaBC0NJeRQsPJaaug3g==", null, false, 8000, "5c7db1d5-ae03-4d26-b134-e2a3cf2fb9e0", false, "admin.two@labguide.com" },
                    { "3", 0, "Spoorwegstraat 4", "Brugge", "48d6fd70-6979-4a74-ba57-d64d1bcdf66f", new DateTime(2006, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user.one@labguide.com", true, "User", "One", false, null, "USER.ONE@LABGUIDE.COM", "USER.ONE@LABGUIDE.COM", "AQAAAAEAACcQAAAAEKegUpZ9xK4HxANooYc/Er50sjP5278j46y+BVm+Lq724MFWlr0avwOA91tuDLefMQ==", null, false, 8000, "a49f0642-83f2-49f9-8c7c-8b7a058d4540", false, "user.one@labguide.com" },
                    { "4", 0, "Spoorwegstraat 4", "Brugge", "40a7b647-03d1-4673-961b-bf074a706024", new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user.two@labguide.com", true, "User", "Two", false, null, "USER.TWO@LABGUIDE.COM", "USER.TWO@LABGUIDE.COM", "AQAAAAEAACcQAAAAEOS8UGbeO2AMd6KU6CITQchCC5KjC1L6e9XBRF7NdS+n6skDu3XBoI1Zdf8QNyt4VQ==", null, false, 8000, "61a872b3-e883-4033-8f9a-948edcade2e8", false, "user.two@labguide.com" },
                    { "5", 0, "Spoorwegstraat 4", "Brugge", "076b328b-5241-458c-99ab-5d035c99a78b", new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "user.three@labguide.com", true, "User", "Three", false, null, "USER.THREE@LABGUIDE.COM", "USER.THREE@LABGUIDE.COM", "AQAAAAEAACcQAAAAEAIaq3lrcZ9VCLy+itxltXqjCGtlD4l97Z1xt/OmbcXUTEYEt4OuPBGaS8UMAugHgg==", null, false, 8000, "8ce5fb6c-f022-401c-a615-d6674f9c2765", false, "user.three@labguide.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "role", "admin", "1" },
                    { 2, "role", "admin2", "2" },
                    { 3, "role", "user", "3" },
                    { 4, "role", "user", "4" },
                    { 5, "role", "user", "5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");
        }
    }
}
