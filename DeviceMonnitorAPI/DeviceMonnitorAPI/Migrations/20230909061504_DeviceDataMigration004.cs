using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class DeviceDataMigration004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("2d868e95-1d1a-44e6-84cb-8e50973fb4ab"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("3d596906-359a-4780-b8f7-4cbf69f78f1f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("4da741d4-7e8f-4785-9a2f-4e2997222cd3"));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "WeatherDeviceData",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("94a0bb8b-2126-4041-8dba-1e4d520c9b44"), new DateTime(2023, 9, 9, 11, 15, 4, 339, DateTimeKind.Local).AddTicks(297), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("3f4a6a68-90da-4ea3-8439-fa4412fd9020"), new DateTime(2023, 9, 9, 11, 15, 4, 339, DateTimeKind.Local).AddTicks(6776), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("eebe69d7-d25f-4f73-9cc9-b8ded86151b8"), new DateTime(2023, 9, 9, 11, 15, 4, 339, DateTimeKind.Local).AddTicks(6789), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Device", true, "User", "_MyP0werfulDev!ce", "device", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "device" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("3f4a6a68-90da-4ea3-8439-fa4412fd9020"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("94a0bb8b-2126-4041-8dba-1e4d520c9b44"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("eebe69d7-d25f-4f73-9cc9-b8ded86151b8"));

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "WeatherDeviceData");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("4da741d4-7e8f-4785-9a2f-4e2997222cd3"), new DateTime(2023, 9, 9, 10, 47, 22, 311, DateTimeKind.Local).AddTicks(9905), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("2d868e95-1d1a-44e6-84cb-8e50973fb4ab"), new DateTime(2023, 9, 9, 10, 47, 22, 312, DateTimeKind.Local).AddTicks(6526), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("3d596906-359a-4780-b8f7-4cbf69f78f1f"), new DateTime(2023, 9, 9, 10, 47, 22, 312, DateTimeKind.Local).AddTicks(6539), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Device", true, "User", "_MyP0werfulDev!ce", "device", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "device" }
                });
        }
    }
}
