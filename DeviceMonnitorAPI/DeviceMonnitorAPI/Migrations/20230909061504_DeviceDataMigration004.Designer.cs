﻿// <auto-generated />
using System;
using DeviceMonnitorAPI.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeviceMonnitorAPI.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230909061504_DeviceDataMigration004")]
    partial class DeviceDataMigration004
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataAI", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DataGuid")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Param")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DataGuid");

                    b.ToTable("DataAI");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataAO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DataGuid")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Param")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DataGuid");

                    b.ToTable("DataAO");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataDI", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DataGuid")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Param")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DataGuid");

                    b.ToTable("DataDI");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataDO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DataGuid")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Param")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DataGuid");

                    b.ToTable("DataDO");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataMEATADATA", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DataGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("Param")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DataGuid");

                    b.ToTable("DataMEATADATA");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.Device", b =>
                {
                    b.Property<Guid>("DeviceGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EditedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("DeviceGuid")
                        .HasName("PK_Device");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceConfig", b =>
                {
                    b.Property<Guid>("ConfGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Cadw")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Calm")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Cup")
                        .HasColumnType("numeric");

                    b.Property<bool>("DO0")
                        .HasColumnType("boolean");

                    b.Property<bool>("DO1")
                        .HasColumnType("boolean");

                    b.Property<bool>("DO2")
                        .HasColumnType("boolean");

                    b.Property<bool>("DO3")
                        .HasColumnType("boolean");

                    b.Property<Guid>("DeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("DownTime")
                        .HasColumnType("integer");

                    b.Property<int>("EMode")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EditedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("EditedUserIdUserGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("Ertime")
                        .HasColumnType("integer");

                    b.Property<int>("LowVtime")
                        .HasColumnType("integer");

                    b.Property<int>("Ontime")
                        .HasColumnType("integer");

                    b.Property<int>("OverVtime")
                        .HasColumnType("integer");

                    b.Property<int>("Overtime")
                        .HasColumnType("integer");

                    b.Property<decimal>("UMax")
                        .HasColumnType("numeric");

                    b.Property<decimal>("UMin")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Wdw")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Wup")
                        .HasColumnType("numeric");

                    b.HasKey("ConfGuid");

                    b.HasIndex("DeviceGuid");

                    b.HasIndex("EditedUserIdUserGuid");

                    b.ToTable("DeviceConfig");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceConfigItem", b =>
                {
                    b.Property<Guid>("ConfGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EditedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("ConfGuid");

                    b.HasIndex("DeviceGuid");

                    b.ToTable("DeviceConfigItem");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EditedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceGuid");

                    b.ToTable("DeviceData");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceUser", b =>
                {
                    b.Property<Guid>("DevicesDeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersUserGuid")
                        .HasColumnType("uuid");

                    b.Property<bool>("CanEdit")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("DeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserGuid")
                        .HasColumnType("uuid");

                    b.HasKey("DevicesDeviceGuid", "UsersUserGuid");

                    b.HasIndex("DeviceGuid");

                    b.HasIndex("UserGuid");

                    b.HasIndex("UsersUserGuid");

                    b.ToTable("DeviceUsers");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.ParamName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NameDomain")
                        .HasColumnType("text");

                    b.Property<int>("NameIndex")
                        .HasColumnType("integer");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_ParamName");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("ParamName");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.User", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EditedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<DateTime>("TokenExpire")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserGuid")
                        .HasName("PK_Users");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserGuid = new Guid("94a0bb8b-2126-4041-8dba-1e4d520c9b44"),
                            CreatedDate = new DateTime(2023, 9, 9, 11, 15, 4, 339, DateTimeKind.Local).AddTicks(297),
                            EditedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Api",
                            IsActive = true,
                            LastName = "Admin",
                            Password = "@p!Adm!n21U$er00222",
                            Role = "ApiAdmin",
                            TokenExpire = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "apiadmin"
                        },
                        new
                        {
                            UserGuid = new Guid("3f4a6a68-90da-4ea3-8439-fa4412fd9020"),
                            CreatedDate = new DateTime(2023, 9, 9, 11, 15, 4, 339, DateTimeKind.Local).AddTicks(6776),
                            EditedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Admin",
                            IsActive = true,
                            LastName = "User",
                            Password = "@@dm!nU$er",
                            Role = "Admin",
                            TokenExpire = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "admin"
                        },
                        new
                        {
                            UserGuid = new Guid("eebe69d7-d25f-4f73-9cc9-b8ded86151b8"),
                            CreatedDate = new DateTime(2023, 9, 9, 11, 15, 4, 339, DateTimeKind.Local).AddTicks(6789),
                            EditedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Device",
                            IsActive = true,
                            LastName = "User",
                            Password = "_MyP0werfulDev!ce",
                            Role = "device",
                            TokenExpire = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "device"
                        });
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.WeatherDeviceData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Aqi")
                        .HasColumnType("double precision");

                    b.Property<double>("Co")
                        .HasColumnType("double precision");

                    b.Property<double>("Co2")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DeviceDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EditedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Humadity")
                        .HasColumnType("double precision");

                    b.Property<double>("Pm1")
                        .HasColumnType("double precision");

                    b.Property<double>("Pm10")
                        .HasColumnType("double precision");

                    b.Property<double>("Pm2_5")
                        .HasColumnType("double precision");

                    b.Property<double>("Rain")
                        .HasColumnType("double precision");

                    b.Property<double>("SandElectric")
                        .HasColumnType("double precision");

                    b.Property<double>("SandHumadity")
                        .HasColumnType("double precision");

                    b.Property<double>("SandSalt")
                        .HasColumnType("double precision");

                    b.Property<double>("SandSaltElectric")
                        .HasColumnType("double precision");

                    b.Property<double>("SandTemperature")
                        .HasColumnType("double precision");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.Property<double>("WindDirection")
                        .HasColumnType("double precision");

                    b.Property<double>("WindSpeed")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("DeviceGuid");

                    b.ToTable("WeatherDeviceData");
                });

            modelBuilder.Entity("DeviceParamName", b =>
                {
                    b.Property<Guid>("DevicesDeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParamNamesId")
                        .HasColumnType("uuid");

                    b.HasKey("DevicesDeviceGuid", "ParamNamesId");

                    b.HasIndex("ParamNamesId");

                    b.ToTable("DeviceParamName");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataAI", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.DeviceData", "DeviceData")
                        .WithMany("DataAIs")
                        .HasForeignKey("DataGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceData");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataAO", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.DeviceData", "DeviceData")
                        .WithMany("DataAOs")
                        .HasForeignKey("DataGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceData");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataDI", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.DeviceData", "DeviceData")
                        .WithMany("DataDIs")
                        .HasForeignKey("DataGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceData");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataDO", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.DeviceData", "DeviceData")
                        .WithMany("DataDOs")
                        .HasForeignKey("DataGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceData");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DataMEATADATA", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.DeviceData", "DeviceData")
                        .WithMany("DataMetadatas")
                        .HasForeignKey("DataGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceData");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceConfig", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.Device", "Device")
                        .WithMany("DevicesConfig")
                        .HasForeignKey("DeviceGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeviceMonnitorAPI.DBModels.User", "EditedUserId")
                        .WithMany()
                        .HasForeignKey("EditedUserIdUserGuid");

                    b.Navigation("Device");

                    b.Navigation("EditedUserId");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceConfigItem", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.Device", "Device")
                        .WithMany("DevicesConfigItem")
                        .HasForeignKey("DeviceGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceData", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.Device", "Device")
                        .WithMany("DevicesData")
                        .HasForeignKey("DeviceGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceUser", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.Device", null)
                        .WithMany("DeviceUsers")
                        .HasForeignKey("DeviceGuid");

                    b.HasOne("DeviceMonnitorAPI.DBModels.Device", null)
                        .WithMany()
                        .HasForeignKey("DevicesDeviceGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeviceMonnitorAPI.DBModels.User", null)
                        .WithMany("DeviceUsers")
                        .HasForeignKey("UserGuid");

                    b.HasOne("DeviceMonnitorAPI.DBModels.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.WeatherDeviceData", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.Device", "Device")
                        .WithMany("WeatherDevicesData")
                        .HasForeignKey("DeviceGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DeviceParamName", b =>
                {
                    b.HasOne("DeviceMonnitorAPI.DBModels.Device", null)
                        .WithMany()
                        .HasForeignKey("DevicesDeviceGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeviceMonnitorAPI.DBModels.ParamName", null)
                        .WithMany()
                        .HasForeignKey("ParamNamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.Device", b =>
                {
                    b.Navigation("DevicesConfig");

                    b.Navigation("DevicesConfigItem");

                    b.Navigation("DevicesData");

                    b.Navigation("DeviceUsers");

                    b.Navigation("WeatherDevicesData");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.DeviceData", b =>
                {
                    b.Navigation("DataAIs");

                    b.Navigation("DataAOs");

                    b.Navigation("DataDIs");

                    b.Navigation("DataDOs");

                    b.Navigation("DataMetadatas");
                });

            modelBuilder.Entity("DeviceMonnitorAPI.DBModels.User", b =>
                {
                    b.Navigation("DeviceUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
