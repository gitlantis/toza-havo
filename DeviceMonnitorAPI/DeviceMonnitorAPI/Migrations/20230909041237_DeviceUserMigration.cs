using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class DeviceUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("50961d2e-a50b-4fdc-be08-a63aa079e4be"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("c47757a2-bdd4-4700-be7e-d36710f38efc"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("157a1c21-c516-4350-a5d8-49b1e490c934"), new DateTime(2023, 9, 9, 9, 12, 37, 431, DateTimeKind.Local).AddTicks(5188), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("88368f8b-a07d-4e41-a1b3-547437831131"), new DateTime(2023, 9, 9, 9, 12, 37, 432, DateTimeKind.Local).AddTicks(2160), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("1a231b4e-dec9-473c-a500-73aac958cb48"), new DateTime(2023, 9, 9, 9, 12, 37, 432, DateTimeKind.Local).AddTicks(2177), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Device", true, "User", "_MyP0werfulDev!ce", "Device", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "device" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("157a1c21-c516-4350-a5d8-49b1e490c934"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("1a231b4e-dec9-473c-a500-73aac958cb48"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserGuid",
                keyValue: new Guid("88368f8b-a07d-4e41-a1b3-547437831131"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("50961d2e-a50b-4fdc-be08-a63aa079e4be"), new DateTime(2023, 8, 31, 18, 47, 41, 669, DateTimeKind.Local).AddTicks(5637), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("c47757a2-bdd4-4700-be7e-d36710f38efc"), new DateTime(2023, 8, 31, 18, 47, 41, 670, DateTimeKind.Local).AddTicks(2321), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" }
                });
        }
    }
}
