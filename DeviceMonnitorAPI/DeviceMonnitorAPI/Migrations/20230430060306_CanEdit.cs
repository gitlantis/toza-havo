using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class CanEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("7dc3fc5e-e413-4d25-9381-3fce03209c18"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("80d36dd1-7f50-436d-ab80-485ce0acd3a9"));

            migrationBuilder.AddColumn<Guid>(
                name: "EditedUserIdUserGuid",
                table: "DeviceConfig",
                type: "char(36)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("6c1f92c1-0fc3-4f37-912a-1a739c461293"), new DateTime(2023, 4, 30, 11, 3, 5, 876, DateTimeKind.Local).AddTicks(7438), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("26c45cc7-b257-4f2e-b817-6454f5a7c1c1"), new DateTime(2023, 4, 30, 11, 3, 5, 877, DateTimeKind.Local).AddTicks(5270), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceConfig_EditedUserIdUserGuid",
                table: "DeviceConfig",
                column: "EditedUserIdUserGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceConfig_Users_EditedUserIdUserGuid",
                table: "DeviceConfig",
                column: "EditedUserIdUserGuid",
                principalTable: "Users",
                principalColumn: "UserGuid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceConfig_Users_EditedUserIdUserGuid",
                table: "DeviceConfig");

            migrationBuilder.DropIndex(
                name: "IX_DeviceConfig_EditedUserIdUserGuid",
                table: "DeviceConfig");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("26c45cc7-b257-4f2e-b817-6454f5a7c1c1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("6c1f92c1-0fc3-4f37-912a-1a739c461293"));

            migrationBuilder.DropColumn(
                name: "EditedUserIdUserGuid",
                table: "DeviceConfig");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("80d36dd1-7f50-436d-ab80-485ce0acd3a9"), new DateTime(2023, 1, 25, 15, 31, 10, 165, DateTimeKind.Local).AddTicks(8218), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("7dc3fc5e-e413-4d25-9381-3fce03209c18"), new DateTime(2023, 1, 25, 15, 31, 10, 166, DateTimeKind.Local).AddTicks(5323), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }
    }
}
