using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StationMonnitorAPI.Migrations
{
    public partial class BaseMigration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParamName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StationGuid = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "StationDataParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Param = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationDataParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationGuid);
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
                name: "ParamNameStation",
                columns: table => new
                {
                    ParamNamesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationsStationGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamNameStation", x => new { x.ParamNamesId, x.StationsStationGuid });
                    table.ForeignKey(
                        name: "FK_ParamNameStation_ParamName_ParamNamesId",
                        column: x => x.ParamNamesId,
                        principalTable: "ParamName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParamNameStation_Stations_StationsStationGuid",
                        column: x => x.StationsStationGuid,
                        principalTable: "Stations",
                        principalColumn: "StationGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationConfigItem",
                columns: table => new
                {
                    ConfGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    StationGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationConfigItem", x => x.ConfGuid);
                    table.ForeignKey(
                        name: "FK_StationConfigItem_Stations_StationGuid",
                        column: x => x.StationGuid,
                        principalTable: "Stations",
                        principalColumn: "StationGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StationGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    A00 = table.Column<double>(type: "double precision", nullable: true),
                    A01 = table.Column<double>(type: "double precision", nullable: true),
                    A02 = table.Column<double>(type: "double precision", nullable: true),
                    A03 = table.Column<double>(type: "double precision", nullable: true),
                    A04 = table.Column<double>(type: "double precision", nullable: true),
                    A05 = table.Column<double>(type: "double precision", nullable: true),
                    A06 = table.Column<double>(type: "double precision", nullable: true),
                    A07 = table.Column<double>(type: "double precision", nullable: true),
                    A08 = table.Column<double>(type: "double precision", nullable: true),
                    A09 = table.Column<double>(type: "double precision", nullable: true),
                    A10 = table.Column<double>(type: "double precision", nullable: true),
                    A11 = table.Column<double>(type: "double precision", nullable: true),
                    A12 = table.Column<double>(type: "double precision", nullable: true),
                    A13 = table.Column<double>(type: "double precision", nullable: true),
                    A14 = table.Column<double>(type: "double precision", nullable: true),
                    A15 = table.Column<double>(type: "double precision", nullable: true),
                    A16 = table.Column<double>(type: "double precision", nullable: true),
                    A17 = table.Column<double>(type: "double precision", nullable: true),
                    A18 = table.Column<double>(type: "double precision", nullable: true),
                    A19 = table.Column<double>(type: "double precision", nullable: true),
                    A20 = table.Column<double>(type: "double precision", nullable: true),
                    A21 = table.Column<double>(type: "double precision", nullable: true),
                    A22 = table.Column<double>(type: "double precision", nullable: true),
                    A23 = table.Column<double>(type: "double precision", nullable: true),
                    A24 = table.Column<double>(type: "double precision", nullable: true),
                    A25 = table.Column<double>(type: "double precision", nullable: true),
                    A26 = table.Column<double>(type: "double precision", nullable: true),
                    A27 = table.Column<double>(type: "double precision", nullable: true),
                    A28 = table.Column<double>(type: "double precision", nullable: true),
                    A29 = table.Column<double>(type: "double precision", nullable: true),
                    A30 = table.Column<double>(type: "double precision", nullable: true),
                    A31 = table.Column<double>(type: "double precision", nullable: true),
                    StationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationData_Stations_StationGuid",
                        column: x => x.StationGuid,
                        principalTable: "Stations",
                        principalColumn: "StationGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationConfig",
                columns: table => new
                {
                    ConfGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    StationGuid = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_StationConfig", x => x.ConfGuid);
                    table.ForeignKey(
                        name: "FK_StationConfig_Stations_StationGuid",
                        column: x => x.StationGuid,
                        principalTable: "Stations",
                        principalColumn: "StationGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationConfig_Users_EditedUserIdUserGuid",
                        column: x => x.EditedUserIdUserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StationUsers",
                columns: table => new
                {
                    StationsStationGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersUserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CanEdit = table.Column<bool>(type: "boolean", nullable: false),
                    StationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationUsers", x => new { x.StationsStationGuid, x.UsersUserGuid });
                    table.ForeignKey(
                        name: "FK_StationUsers_Stations_StationGuid",
                        column: x => x.StationGuid,
                        principalTable: "Stations",
                        principalColumn: "StationGuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationUsers_Stations_StationsStationGuid",
                        column: x => x.StationsStationGuid,
                        principalTable: "Stations",
                        principalColumn: "StationGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationUsers_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationUsers_Users_UsersUserGuid",
                        column: x => x.UsersUserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StationDataParams",
                columns: new[] { "Id", "Description", "Name", "Param" },
                values: new object[,]
                {
                    { new Guid("db2c1720-7a10-4e38-afe6-50473d8bc51d"), "Air temperature", "AirTemperature", "A00" },
                    { new Guid("7f33f4db-c365-417e-8f78-9c3692963d83"), "Wind speed m/s", "windSpeed", "A20" },
                    { new Guid("71b5f93d-b8a4-4a6f-ae03-88e23b523722"), "Wind direction", "windDeirection", "A21" },
                    { new Guid("bef8d17d-d2d8-49ce-884e-57fa6565bcdb"), "Leaf temperature", "leafTmeperature", "A22" },
                    { new Guid("26359fd4-046a-4198-b5b2-4d7f2e3b90bb"), "Leaf humadity", "leafumadity", "A23" },
                    { new Guid("cc710e02-cb5c-46bc-912e-1a613db92e3d"), "Langitude", "gpsLang", "A24" },
                    { new Guid("1d3fe4e0-cccf-4016-9cab-14a956b53084"), "Latitude", "gpsLat", "A25" },
                    { new Guid("f382603e-0a3d-4632-907f-f6213d3ef5a4"), "Soil salting", "soilSaliness", "A19" },
                    { new Guid("9d90c9ba-3bf6-4470-ae97-dafa6c5458b6"), "Altitude", "gpsAlt", "A26" },
                    { new Guid("a7463f77-70d2-4f8d-9b43-a1aed53bdf39"), "Air pressure", "pressure", "A28" },
                    { new Guid("72496a24-a7ea-4980-9226-73ff18933bd1"), "Solar radiation", "radiation", "A29" },
                    { new Guid("b9efeaa7-5137-4782-ab4c-dbd22ccbb7e8"), "Reserve03", "reserve03", "A30" },
                    { new Guid("5369d165-e2a6-413a-a4c6-edcaf7236456"), "Reserve04", "reserve04", "A31" },
                    { new Guid("d94ae2d5-be08-4324-8646-7610dd853cdc"), "Stations information date", "StationDate", "StationDate" },
                    { new Guid("65b7d8d7-9f6a-40b8-bfa4-4b25773d1d84"), "Stations information created date", "CreatedDate", "CreatedDate" },
                    { new Guid("a9f0a1dd-847b-4607-82d0-2214c5b94aae"), "Accumulator voltage", "accVoltage", "A27" },
                    { new Guid("f931a8f8-c5a9-4450-93f1-ee342b4820d9"), "Soil temperature", "soilTemperature", "A17" },
                    { new Guid("1c016d5d-3866-4b78-a898-ffafa2988298"), "Soil humadity", "soilHumadity", "A18" },
                    { new Guid("e44b7484-47dc-49ba-88f8-a2ec2af320cf"), "AirPMAdd3", "AirPMAdd3", "A07" },
                    { new Guid("fad3d17a-b62f-4150-81ec-b46c532aa13c"), "Gas CO", "gasCOppm", "A15" },
                    { new Guid("db47e2db-05f8-4173-8b84-6661992e8d3d"), "Gas CO2", "gasCO2ppm", "A14" },
                    { new Guid("8fcd9dd0-bbef-4fb5-83a1-2afbd819030d"), "AirPMAdd9", "AirPMAdd9", "A13" },
                    { new Guid("a937fef1-ca23-4d98-90cb-da28396045af"), "AirPMAdd8", "AirPMAdd8", "A12" },
                    { new Guid("3e7e9cea-83df-4112-9520-9cd1e961d5e0"), "AirPMAdd7", "AirPMAdd7", "A11" },
                    { new Guid("f0f31eb6-8b8e-43f1-9ff3-810ae4f71a68"), "AirPMAdd6", "AirPMAdd6", "A10" },
                    { new Guid("ca7d4b6a-c98b-4da6-9d25-ba02e960c682"), "AirPMAdd5", "AirPMAdd5", "A09" },
                    { new Guid("eb3366e9-19f5-43d5-81f7-5e0d8faeca36"), "AirPMAdd4", "AirPMAdd4", "A08" },
                    { new Guid("8352302e-b9bc-4e77-b903-fa6ecdd2b7d7"), "Soil conductivity", "soilConductivity", "A16" },
                    { new Guid("fc2b4ba5-06b0-4ec6-9fca-2c352a8aabdc"), "AirPMAdd2", "AirPMAdd2", "A06" },
                    { new Guid("48aa0550-83db-4865-b08c-28c17b5d060f"), "AirPMAdd1", "AirPMAdd1", "A05" },
                    { new Guid("98d1809d-e887-448d-b5e4-044dad9198b1"), "Air dist PM10", "AirPM10_", "A04" },
                    { new Guid("f9fb4589-8d0f-47ae-a276-9ce2b876b6ba"), "Air dist PM2.5", "AirPM2_5", "A03" },
                    { new Guid("ff7e861d-19ca-427e-b95e-26decf89456b"), "Air dist PM1.0", "AirPM1_0", "A02" },
                    { new Guid("2e7226c8-4701-45a2-8aba-c9f471f852a1"), "Air humadity", "AirHumadity", "A01" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserGuid", "CreatedDate", "Description", "EditedDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Token", "TokenExpire", "Username" },
                values: new object[,]
                {
                    { new Guid("be501b00-2e11-4a06-b239-e56c18c5260c"), new DateTime(2023, 9, 20, 19, 49, 56, 539, DateTimeKind.Local).AddTicks(5943), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "User", "@@dm!nU$er", "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("47312805-1cb2-4bca-95e3-fee35d7c34a3"), new DateTime(2023, 9, 20, 19, 49, 56, 538, DateTimeKind.Local).AddTicks(9193), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api", true, "Admin", "@p!Adm!n21U$er00222", "ApiAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apiadmin" },
                    { new Guid("81931a1f-0bd1-4402-a66a-9d2796de4cca"), new DateTime(2023, 9, 20, 19, 49, 56, 539, DateTimeKind.Local).AddTicks(5956), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Station", true, "User", "_MyP0werfulDev!ce", "station", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "station" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParamName_Id",
                table: "ParamName",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParamNameStation_StationsStationGuid",
                table: "ParamNameStation",
                column: "StationsStationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StationConfig_EditedUserIdUserGuid",
                table: "StationConfig",
                column: "EditedUserIdUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StationConfig_StationGuid",
                table: "StationConfig",
                column: "StationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StationConfigItem_StationGuid",
                table: "StationConfigItem",
                column: "StationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StationData_StationGuid",
                table: "StationData",
                column: "StationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StationUsers_StationGuid",
                table: "StationUsers",
                column: "StationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StationUsers_UserGuid",
                table: "StationUsers",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StationUsers_UsersUserGuid",
                table: "StationUsers",
                column: "UsersUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParamNameStation");

            migrationBuilder.DropTable(
                name: "StationConfig");

            migrationBuilder.DropTable(
                name: "StationConfigItem");

            migrationBuilder.DropTable(
                name: "StationData");

            migrationBuilder.DropTable(
                name: "StationDataParams");

            migrationBuilder.DropTable(
                name: "StationUsers");

            migrationBuilder.DropTable(
                name: "ParamName");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
