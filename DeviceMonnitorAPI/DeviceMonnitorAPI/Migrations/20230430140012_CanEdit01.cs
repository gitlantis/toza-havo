using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class CanEdit01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceUser");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("26c45cc7-b257-4f2e-b817-6454f5a7c1c1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("6c1f92c1-0fc3-4f37-912a-1a739c461293"));

            migrationBuilder.CreateTable(
                name: "DeviceUsers",
                columns: table => new
                {
                    DevicesDeviceGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    UsersUserGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "char(36)", nullable: true),
                    UserGuid = table.Column<Guid>(type: "char(36)", nullable: true),
                    CanEdit = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUsers", x => new { x.DevicesDeviceGuid, x.UsersUserGuid });
                    table.ForeignKey(
                        name: "FK_DeviceUsers_Device_DeviceGuid",
                        column: x => x.DeviceGuid,
                        principalTable: "Device",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceUsers_Device_DevicesDeviceGuid",
                        column: x => x.DevicesDeviceGuid,
                        principalTable: "Device",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUsers_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceUsers_Users_UsersUserGuid",
                        column: x => x.UsersUserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUsers_UsersUserGuid",
                table: "DeviceUsers",
                column: "UsersUserGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceUsers");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("2065919c-c898-4bca-97bc-f459e8a8751d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("3ca1a2c6-8940-49a9-b60a-084b5da46a1b"));

            migrationBuilder.CreateTable(
                name: "DeviceUser",
                columns: table => new
                {
                    DevicesDeviceGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    UsersUserGuid = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUser", x => new { x.DevicesDeviceGuid, x.UsersUserGuid });
                    table.ForeignKey(
                        name: "FK_DeviceUser_Device_DevicesDeviceGuid",
                        column: x => x.DevicesDeviceGuid,
                        principalTable: "Device",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUser_Users_UsersUserGuid",
                        column: x => x.UsersUserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("6c1f92c1-0fc3-4f37-912a-1a739c461293"), new DateTime(2023, 4, 30, 11, 3, 5, 876, DateTimeKind.Local).AddTicks(7438), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("26c45cc7-b257-4f2e-b817-6454f5a7c1c1"), new DateTime(2023, 4, 30, 11, 3, 5, 877, DateTimeKind.Local).AddTicks(5270), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUser_UsersUserGuid",
                table: "DeviceUser",
                column: "UsersUserGuid");
        }
    }
}
