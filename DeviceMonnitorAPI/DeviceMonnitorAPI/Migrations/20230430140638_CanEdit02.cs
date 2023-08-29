using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class CanEdit02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceUsers_Device_DeviceGuid",
                table: "DeviceUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceUsers_Users_UserGuid",
                table: "DeviceUsers");

            migrationBuilder.DropIndex(
                name: "IX_DeviceUsers_DeviceGuid",
                table: "DeviceUsers");

            migrationBuilder.DropIndex(
                name: "IX_DeviceUsers_UserGuid",
                table: "DeviceUsers");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("2065919c-c898-4bca-97bc-f459e8a8751d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("3ca1a2c6-8940-49a9-b60a-084b5da46a1b"));

            migrationBuilder.DropColumn(
                name: "DeviceGuid",
                table: "DeviceUsers");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "DeviceUsers");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("cd975c4b-ba17-4b79-a452-ff3494bbfadf"), new DateTime(2023, 4, 30, 19, 6, 37, 872, DateTimeKind.Local).AddTicks(2940), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("65578ca5-876b-49f0-b1e8-7f88960991d1"), new DateTime(2023, 4, 30, 19, 6, 37, 872, DateTimeKind.Local).AddTicks(9494), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("65578ca5-876b-49f0-b1e8-7f88960991d1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("cd975c4b-ba17-4b79-a452-ff3494bbfadf"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceGuid",
                table: "DeviceUsers",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "DeviceUsers",
                type: "char(36)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("2065919c-c898-4bca-97bc-f459e8a8751d"), new DateTime(2023, 4, 30, 19, 0, 12, 158, DateTimeKind.Local).AddTicks(4407), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("3ca1a2c6-8940-49a9-b60a-084b5da46a1b"), new DateTime(2023, 4, 30, 19, 0, 12, 159, DateTimeKind.Local).AddTicks(3929), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUsers_DeviceGuid",
                table: "DeviceUsers",
                column: "DeviceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUsers_UserGuid",
                table: "DeviceUsers",
                column: "UserGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceUsers_Device_DeviceGuid",
                table: "DeviceUsers",
                column: "DeviceGuid",
                principalTable: "Device",
                principalColumn: "DeviceGuid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceUsers_Users_UserGuid",
                table: "DeviceUsers",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "UserGuid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
