using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class UpdateMigrateData001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "WindSpeed",
                table: "WeatherDeviceData",
                newName: "A31");

            migrationBuilder.RenameColumn(
                name: "WindDirection",
                table: "WeatherDeviceData",
                newName: "A30");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "WeatherDeviceData",
                newName: "A29");

            migrationBuilder.RenameColumn(
                name: "SandTemperature",
                table: "WeatherDeviceData",
                newName: "A28");

            migrationBuilder.RenameColumn(
                name: "SandSaltElectric",
                table: "WeatherDeviceData",
                newName: "A27");

            migrationBuilder.RenameColumn(
                name: "SandSalt",
                table: "WeatherDeviceData",
                newName: "A26");

            migrationBuilder.RenameColumn(
                name: "SandHumadity",
                table: "WeatherDeviceData",
                newName: "A25");

            migrationBuilder.RenameColumn(
                name: "SandElectric",
                table: "WeatherDeviceData",
                newName: "A24");

            migrationBuilder.RenameColumn(
                name: "Rain",
                table: "WeatherDeviceData",
                newName: "A23");

            migrationBuilder.RenameColumn(
                name: "Pm2_5",
                table: "WeatherDeviceData",
                newName: "A22");

            migrationBuilder.RenameColumn(
                name: "Pm10",
                table: "WeatherDeviceData",
                newName: "A21");

            migrationBuilder.RenameColumn(
                name: "Pm1",
                table: "WeatherDeviceData",
                newName: "A20");

            migrationBuilder.RenameColumn(
                name: "Humadity",
                table: "WeatherDeviceData",
                newName: "A19");

            migrationBuilder.RenameColumn(
                name: "Co2",
                table: "WeatherDeviceData",
                newName: "A18");

            migrationBuilder.RenameColumn(
                name: "Co",
                table: "WeatherDeviceData",
                newName: "A17");

            migrationBuilder.RenameColumn(
                name: "Aqi",
                table: "WeatherDeviceData",
                newName: "A16");

            migrationBuilder.AddColumn<double>(
                name: "A00",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A01",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A02",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A03",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A04",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A05",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A06",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A07",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A08",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A09",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A10",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A11",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A12",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A13",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A14",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "A15",
                table: "WeatherDeviceData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("3df13295-f052-4b40-862c-662f6e934ec3"), new DateTime(2023, 9, 10, 21, 53, 31, 757, DateTimeKind.Local).AddTicks(5582), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("92e9fdf5-8712-408f-bea6-5a514d9d02f9"), new DateTime(2023, 9, 10, 21, 53, 31, 758, DateTimeKind.Local).AddTicks(1544), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("a594e337-c6a6-448a-bc0d-ba24ec5843ed"), new DateTime(2023, 9, 10, 21, 53, 31, 758, DateTimeKind.Local).AddTicks(1557), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Device", true, "User", "_MyP0werfulDev!ce", "device", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "device" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("3df13295-f052-4b40-862c-662f6e934ec3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("92e9fdf5-8712-408f-bea6-5a514d9d02f9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("a594e337-c6a6-448a-bc0d-ba24ec5843ed"));

            migrationBuilder.DropColumn(
                name: "A00",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A01",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A02",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A03",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A04",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A05",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A06",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A07",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A08",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A09",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A10",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A11",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A12",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A13",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A14",
                table: "WeatherDeviceData");

            migrationBuilder.DropColumn(
                name: "A15",
                table: "WeatherDeviceData");

            migrationBuilder.RenameColumn(
                name: "A31",
                table: "WeatherDeviceData",
                newName: "WindSpeed");

            migrationBuilder.RenameColumn(
                name: "A30",
                table: "WeatherDeviceData",
                newName: "WindDirection");

            migrationBuilder.RenameColumn(
                name: "A29",
                table: "WeatherDeviceData",
                newName: "Temperature");

            migrationBuilder.RenameColumn(
                name: "A28",
                table: "WeatherDeviceData",
                newName: "SandTemperature");

            migrationBuilder.RenameColumn(
                name: "A27",
                table: "WeatherDeviceData",
                newName: "SandSaltElectric");

            migrationBuilder.RenameColumn(
                name: "A26",
                table: "WeatherDeviceData",
                newName: "SandSalt");

            migrationBuilder.RenameColumn(
                name: "A25",
                table: "WeatherDeviceData",
                newName: "SandHumadity");

            migrationBuilder.RenameColumn(
                name: "A24",
                table: "WeatherDeviceData",
                newName: "SandElectric");

            migrationBuilder.RenameColumn(
                name: "A23",
                table: "WeatherDeviceData",
                newName: "Rain");

            migrationBuilder.RenameColumn(
                name: "A22",
                table: "WeatherDeviceData",
                newName: "Pm2_5");

            migrationBuilder.RenameColumn(
                name: "A21",
                table: "WeatherDeviceData",
                newName: "Pm10");

            migrationBuilder.RenameColumn(
                name: "A20",
                table: "WeatherDeviceData",
                newName: "Pm1");

            migrationBuilder.RenameColumn(
                name: "A19",
                table: "WeatherDeviceData",
                newName: "Humadity");

            migrationBuilder.RenameColumn(
                name: "A18",
                table: "WeatherDeviceData",
                newName: "Co2");

            migrationBuilder.RenameColumn(
                name: "A17",
                table: "WeatherDeviceData",
                newName: "Co");

            migrationBuilder.RenameColumn(
                name: "A16",
                table: "WeatherDeviceData",
                newName: "Aqi");

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
    }
}
