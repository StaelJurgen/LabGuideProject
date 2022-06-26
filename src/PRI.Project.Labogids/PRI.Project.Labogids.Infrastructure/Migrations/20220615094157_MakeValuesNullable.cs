using Microsoft.EntityFrameworkCore.Migrations;

namespace PRI.Project.Labogids.Infrastructure.Migrations
{
    public partial class MakeValuesNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Period",
                table: "ReferenceValues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "MinimumValue",
                table: "ReferenceValues",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "MaximumValue",
                table: "ReferenceValues",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "MaximalAge",
                table: "ReferenceValues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimType",
                value: "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClaimType",
                value: "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClaimType",
                value: "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "ClaimType",
                value: "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa2daa40-b213-430d-8197-b0827b7b12b4", "AQAAAAEAACcQAAAAEC6qLw016pYIZL5geumgeurevJssHr2vWkvyBw+uy/XL1QFrhKjql3pcSymdYqxUwg==", "7ca947ef-5496-4896-8795-95c683979fe5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "041e23eb-cd91-403f-9d9c-8ba8a7d82eed", "AQAAAAEAACcQAAAAEBLMafMVwQxKfGPmZAw2lfd41CTfXNVbTTCt9V4T7N4f3b6yID9zC+VqsuOo1QYn2A==", "1b26f775-9634-42fc-8bdd-138cae4f25fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e45b4ba2-9710-419f-a353-203029d78682", "AQAAAAEAACcQAAAAEDTm7XIuNwTJ16P4FkC8fqqzaQoWju3oultUuAf3HM7IENDndr96PGWgR6LZvbBT2A==", "25f8544d-0a83-4df3-97db-52db493fe2e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bdecd99-368b-4708-ad78-1d43039ae48c", "AQAAAAEAACcQAAAAEIwG987AmUjfoDFeYiQJAt8qoXwaFkj9m6RfYAeQjLyFWLny06IwfNf9p20RPUtTzg==", "ceeeadea-1cf9-4170-aacf-199e2a1f264d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8805d1b-dfd7-4b5e-82f3-200acf2538e5", "AQAAAAEAACcQAAAAEDl3bDsv3/HBMstHBNSczeilyCxUJAZwEjQrFqDo8Biu9vqe4qrJMBM+P7lvd73FpA==", "4e6a9926-51a7-4ac6-adf7-c637f97a6933" });

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "MaximalAge", "MaximumValue", "MinimumValue" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "MaximalAge",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MaximalAge", "MinimumValue" },
                values: new object[] { null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Period",
                table: "ReferenceValues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinimumValue",
                table: "ReferenceValues",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MaximumValue",
                table: "ReferenceValues",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaximalAge",
                table: "ReferenceValues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimType",
                value: "role");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "role", "admin2" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClaimType",
                value: "role");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClaimType",
                value: "role");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "ClaimType",
                value: "role");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42d56bc5-a5de-4191-9f8a-abe225ef8888", "AQAAAAEAACcQAAAAEAKI3maOZ/x8r1jBUcSGCVzIMjxTmwl6ro3L0RMsF+rJvWK6q+Rw7MYZX6ZJveqKsQ==", "0a007954-d51f-4fd1-9a78-06ccd4ca6725" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6943dd4-609d-48cd-924d-d59a42463d6c", "AQAAAAEAACcQAAAAELlZsPrYPI4IhintOshkL2i85fKewWMgkOh2YbDw9YDWPLEtaBC0NJeRQsPJaaug3g==", "5c7db1d5-ae03-4d26-b134-e2a3cf2fb9e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48d6fd70-6979-4a74-ba57-d64d1bcdf66f", "AQAAAAEAACcQAAAAEKegUpZ9xK4HxANooYc/Er50sjP5278j46y+BVm+Lq724MFWlr0avwOA91tuDLefMQ==", "a49f0642-83f2-49f9-8c7c-8b7a058d4540" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40a7b647-03d1-4673-961b-bf074a706024", "AQAAAAEAACcQAAAAEOS8UGbeO2AMd6KU6CITQchCC5KjC1L6e9XBRF7NdS+n6skDu3XBoI1Zdf8QNyt4VQ==", "61a872b3-e883-4033-8f9a-948edcade2e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "076b328b-5241-458c-99ab-5d035c99a78b", "AQAAAAEAACcQAAAAEAIaq3lrcZ9VCLy+itxltXqjCGtlD4l97Z1xt/OmbcXUTEYEt4OuPBGaS8UMAugHgg==", "8ce5fb6c-f022-401c-a615-d6674f9c2765" });

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "MaximalAge", "MaximumValue", "MinimumValue" },
                values: new object[] { 0, 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "MaximalAge",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReferenceValues",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MaximalAge", "MinimumValue" },
                values: new object[] { 0, 0.0 });
        }
    }
}
