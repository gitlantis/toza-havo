using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class BaseMigration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    DeviceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceGuid);
                });

            migrationBuilder.CreateTable(
                name: "ParamName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameDomain = table.Column<string>(type: "text", nullable: true),
                    NameIndex = table.Column<int>(type: "integer", nullable: false),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TokenExpire = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserGuid);
                });

            migrationBuilder.CreateTable(
                name: "DeviceConfigItem",
                columns: table => new
                {
                    ConfGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceConfigItem", x => x.ConfGuid);
                    table.ForeignKey(
                        name: "FK_DeviceConfigItem_Device_DeviceGuid",
                        column: x => x.DeviceGuid,
                        principalTable: "Device",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceData_Device_DeviceGuid",
                        column: x => x.DeviceGuid,
                        principalTable: "Device",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceParamName",
                columns: table => new
                {
                    DevicesDeviceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ParamNamesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceParamName", x => new { x.DevicesDeviceGuid, x.ParamNamesId });
                    table.ForeignKey(
                        name: "FK_DeviceParamName_Device_DevicesDeviceGuid",
                        column: x => x.DevicesDeviceGuid,
                        principalTable: "Device",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceParamName_ParamName_ParamNamesId",
                        column: x => x.ParamNamesId,
                        principalTable: "ParamName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceConfig",
                columns: table => new
                {
                    ConfGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UMax = table.Column<decimal>(type: "numeric", nullable: false),
                    UMin = table.Column<decimal>(type: "numeric", nullable: false),
                    Cup = table.Column<decimal>(type: "numeric", nullable: false),
                    Calm = table.Column<decimal>(type: "numeric", nullable: false),
                    Cadw = table.Column<decimal>(type: "numeric", nullable: false),
                    Wup = table.Column<decimal>(type: "numeric", nullable: false),
                    Wdw = table.Column<decimal>(type: "numeric", nullable: false),
                    Ontime = table.Column<int>(type: "integer", nullable: false),
                    Ertime = table.Column<int>(type: "integer", nullable: false),
                    Overtime = table.Column<int>(type: "integer", nullable: false),
                    DownTime = table.Column<int>(type: "integer", nullable: false),
                    OverVtime = table.Column<int>(type: "integer", nullable: false),
                    LowVtime = table.Column<int>(type: "integer", nullable: false),
                    EMode = table.Column<int>(type: "integer", nullable: false),
                    DO0 = table.Column<bool>(type: "boolean", nullable: false),
                    DO1 = table.Column<bool>(type: "boolean", nullable: false),
                    DO2 = table.Column<bool>(type: "boolean", nullable: false),
                    DO3 = table.Column<bool>(type: "boolean", nullable: false),
                    EditedUserIdUserGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceConfig", x => x.ConfGuid);
                    table.ForeignKey(
                        name: "FK_DeviceConfig_Device_DeviceGuid",
                        column: x => x.DeviceGuid,
                        principalTable: "Device",
                        principalColumn: "DeviceGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceConfig_Users_EditedUserIdUserGuid",
                        column: x => x.EditedUserIdUserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceUsers",
                columns: table => new
                {
                    DevicesDeviceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CanEdit = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "DataAI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Param = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataAI_DeviceData_DataGuid",
                        column: x => x.DataGuid,
                        principalTable: "DeviceData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Param = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataAO_DeviceData_DataGuid",
                        column: x => x.DataGuid,
                        principalTable: "DeviceData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataDI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Param = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataDI_DeviceData_DataGuid",
                        column: x => x.DataGuid,
                        principalTable: "DeviceData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataDO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Param = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataDO_DeviceData_DataGuid",
                        column: x => x.DataGuid,
                        principalTable: "DeviceData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataMEATADATA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Param = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataMEATADATA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataMEATADATA_DeviceData_DataGuid",
                        column: x => x.DataGuid,
                        principalTable: "DeviceData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("50961d2e-a50b-4fdc-be08-a63aa079e4be"), new DateTime(2023, 8, 31, 18, 47, 41, 669, DateTimeKind.Local).AddTicks(5637), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("c47757a2-bdd4-4700-be7e-d36710f38efc"), new DateTime(2023, 8, 31, 18, 47, 41, 670, DateTimeKind.Local).AddTicks(2321), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataAI_DataGuid",
                table: "DataAI",
                column: "DataGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DataAO_DataGuid",
                table: "DataAO",
                column: "DataGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DataDI_DataGuid",
                table: "DataDI",
                column: "DataGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DataDO_DataGuid",
                table: "DataDO",
                column: "DataGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DataMEATADATA_DataGuid",
                table: "DataMEATADATA",
                column: "DataGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceConfig_DeviceGuid",
                table: "DeviceConfig",
                column: "DeviceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceConfig_EditedUserIdUserGuid",
                table: "DeviceConfig",
                column: "EditedUserIdUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceConfigItem_DeviceGuid",
                table: "DeviceConfigItem",
                column: "DeviceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceData_DeviceGuid",
                table: "DeviceData",
                column: "DeviceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParamName_ParamNamesId",
                table: "DeviceParamName",
                column: "ParamNamesId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ParamName_Id",
                table: "ParamName",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataAI");

            migrationBuilder.DropTable(
                name: "DataAO");

            migrationBuilder.DropTable(
                name: "DataDI");

            migrationBuilder.DropTable(
                name: "DataDO");

            migrationBuilder.DropTable(
                name: "DataMEATADATA");

            migrationBuilder.DropTable(
                name: "DeviceConfig");

            migrationBuilder.DropTable(
                name: "DeviceConfigItem");

            migrationBuilder.DropTable(
                name: "DeviceParamName");

            migrationBuilder.DropTable(
                name: "DeviceUsers");

            migrationBuilder.DropTable(
                name: "DeviceData");

            migrationBuilder.DropTable(
                name: "ParamName");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
