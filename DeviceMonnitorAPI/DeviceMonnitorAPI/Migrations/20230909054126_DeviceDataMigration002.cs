using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class DeviceDataMigration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("6dc25df5-bb5e-4bf3-9765-4eaac5cd3765"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("b63b72ae-98c6-4e0a-84c5-248cb8de7fc6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("d7d7f72a-ee26-41eb-a181-83022c00d798"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("08bfcf4d-2d41-4d53-94dd-43324dbce909"), new DateTime(2023, 9, 9, 10, 41, 26, 579, DateTimeKind.Local).AddTicks(6744), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("179355a3-df4c-4f81-906b-508bbf4f124c"), new DateTime(2023, 9, 9, 10, 41, 26, 580, DateTimeKind.Local).AddTicks(4323), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("72fc7999-64a8-4864-9745-1794f9edfb9d"), new DateTime(2023, 9, 9, 10, 41, 26, 580, DateTimeKind.Local).AddTicks(4353), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Device", true, "User", "_MyP0werfulDev!ce", "device", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "device" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("08bfcf4d-2d41-4d53-94dd-43324dbce909"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("179355a3-df4c-4f81-906b-508bbf4f124c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("72fc7999-64a8-4864-9745-1794f9edfb9d"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("b63b72ae-98c6-4e0a-84c5-248cb8de7fc6"), new DateTime(2023, 9, 9, 10, 19, 34, 443, DateTimeKind.Local).AddTicks(790), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("6dc25df5-bb5e-4bf3-9765-4eaac5cd3765"), new DateTime(2023, 9, 9, 10, 19, 34, 443, DateTimeKind.Local).AddTicks(7055), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("d7d7f72a-ee26-41eb-a181-83022c00d798"), new DateTime(2023, 9, 9, 10, 19, 34, 443, DateTimeKind.Local).AddTicks(7067), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Device", true, "User", "_MyP0werfulDev!ce", "device", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "device" }
                });
        }
    }
}
