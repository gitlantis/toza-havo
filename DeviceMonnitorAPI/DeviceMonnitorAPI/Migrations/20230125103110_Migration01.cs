using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeviceMonnitorAPI.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    DeviceGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceGuid);
                });

            migrationBuilder.CreateTable(
                name: "ParamName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NameDomain = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NameIndex = table.Column<int>(type: "int", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    TokenExpire = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserGuid);
                });

            migrationBuilder.CreateTable(
                name: "DeviceConfig",
                columns: table => new
                {
                    ConfGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    UMax = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UMin = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Cup = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Calm = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Cadw = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Wup = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Wdw = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Ontime = table.Column<int>(type: "int", nullable: false),
                    Ertime = table.Column<int>(type: "int", nullable: false),
                    Overtime = table.Column<int>(type: "int", nullable: false),
                    DownTime = table.Column<int>(type: "int", nullable: false),
                    OverVtime = table.Column<int>(type: "int", nullable: false),
                    LowVtime = table.Column<int>(type: "int", nullable: false),
                    EMode = table.Column<int>(type: "int", nullable: false),
                    DO0 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DO1 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DO2 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DO3 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "DeviceConfigItem",
                columns: table => new
                {
                    ConfGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Comment = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Value = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DeviceGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    DevicesDeviceGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    ParamNamesId = table.Column<Guid>(type: "char(36)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DataAI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Param = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Param = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Param = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Param = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Param = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                values: new object[] { new Guid("80d36dd1-7f50-436d-ab80-485ce0acd3a9"), new DateTime(2023, 1, 25, 15, 31, 10, 165, DateTimeKind.Local).AddTicks(8218), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[] { new Guid("7dc3fc5e-e413-4d25-9381-3fce03209c18"), new DateTime(2023, 1, 25, 15, 31, 10, 166, DateTimeKind.Local).AddTicks(5323), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

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
                name: "IX_DeviceUser_UsersUserGuid",
                table: "DeviceUser",
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
                name: "DeviceUser");

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
