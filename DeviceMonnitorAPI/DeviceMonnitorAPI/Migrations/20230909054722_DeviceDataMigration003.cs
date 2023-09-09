using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class DeviceDataMigration003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "WeatherDeviceData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Co = table.Column<double>(type: "double precision", nullable: false),
                    Co2 = table.Column<double>(type: "double precision", nullable: false),
                    Pm1 = table.Column<double>(type: "double precision", nullable: false),
                    Pm2_5 = table.Column<double>(type: "double precision", nullable: false),
                    Pm10 = table.Column<double>(type: "double precision", nullable: false),
                    Aqi = table.Column<double>(type: "double precision", nullable: false),
                    Humadity = table.Column<double>(type: "double precision", nullable: false),
                    SandHumadity = table.Column<double>(type: "double precision", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    SandTemperature = table.Column<double>(type: "double precision", nullable: false),
                    SandElectric = table.Column<double>(type: "double precision", nullable: false),
                    SandSalt = table.Column<double>(type: "double precision", nullable: false),
                    SandSaltElectric = table.Column<double>(type: "double precision", nullable: false),
                    Rain = table.Column<double>(type: "double precision", nullable: false),
                    WindSpeed = table.Column<double>(type: "double precision", nullable: false),
                    WindDirection = table.Column<double>(type: "double precision", nullable: false),
                    DeviceDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDeviceData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherDeviceData_Device_DeviceGuid",
                        column: x => x.DeviceGuid,
                        principalTable: "Device",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("4da741d4-7e8f-4785-9a2f-4e2997222cd3"), new DateTime(2023, 9, 9, 10, 47, 22, 311, DateTimeKind.Local).AddTicks(9905), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("2d868e95-1d1a-44e6-84cb-8e50973fb4ab"), new DateTime(2023, 9, 9, 10, 47, 22, 312, DateTimeKind.Local).AddTicks(6526), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("3d596906-359a-4780-b8f7-4cbf69f78f1f"), new DateTime(2023, 9, 9, 10, 47, 22, 312, DateTimeKind.Local).AddTicks(6539), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Device", true, "User", "_MyP0werfulDev!ce", "device", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "device" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDeviceData_DeviceGuid",
                table: "WeatherDeviceData",
                column: "DeviceGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherDeviceData");

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
    }
}
