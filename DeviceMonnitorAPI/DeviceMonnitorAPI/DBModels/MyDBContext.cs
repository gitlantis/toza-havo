using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceMonnitorAPI.DBModels
{
    public class MyDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceData> DeviceData { get; set; }
        public DbSet<WeatherDeviceData> WeatherDeviceData { get; set; }
        public DbSet<DeviceConfig> DeviceConfig { get; set; }
        public DbSet<DeviceConfigItem> DeviceConfigItem { get; set; }
        public DbSet<DataAI> DataAI { get; set; }
        public DbSet<DataAO> DataAO { get; set; }
        public DbSet<DataDI> DataDI { get; set; }
        public DbSet<DataDO> DataDO { get; set; }
        public DbSet<DataMEATADATA> DataMEATADATA { get; set; }
        public DbSet<ParamName> ParamNames { get; set; }
        public DbSet<DeviceUser> DeviceUsers { get; set; }


        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().HasMany(d => d.Devices).WithMany(u => u.Users);
            // Configure Primary Keys  
            modelBuilder.Entity<User>().HasKey(u => u.UserGuid).HasName("PK_Users");
            modelBuilder.Entity<User>().HasData(
                new User {UserGuid=Guid.NewGuid(), FirstName = "Api", LastName = "Admin", Username = "apiadmin", Password = "@p!Adm!n21U$er00222", IsActive = true, Role = "ApiAdmin", CreatedDate = DateTime.Now },
                new User { UserGuid = Guid.NewGuid(), FirstName = "Admin", LastName = "User", Username = "admin", Password = "@@dm!nU$er", IsActive = true, Role = "Admin", CreatedDate = DateTime.Now },
                new User { UserGuid = Guid.NewGuid(), FirstName = "Device", LastName = "User", Username = "device", Password = "_MyP0werfulDev!ce", IsActive = true, Role = "device", CreatedDate = DateTime.Now }
                );

            // Map entities to tables  
            modelBuilder.Entity<Device>().ToTable("Device");
            modelBuilder.Entity<Device>().HasKey(u => u.DeviceGuid).HasName("PK_Device");
            modelBuilder.Entity<Device>().HasMany(u => u.Users).WithMany(d => d.Devices)
                .UsingEntity<DeviceUser>(
                l => l.HasOne<User>().WithMany().HasForeignKey(e => e.UsersUserGuid),
                r => r.HasOne<Device>().WithMany().HasForeignKey(e => e.DevicesDeviceGuid));

            // Map entities to tables  
            modelBuilder.Entity<DeviceData>().ToTable("DeviceData");
            modelBuilder.Entity<WeatherDeviceData>().ToTable("WeatherDeviceData");

            // Configure Primary Keys  
            modelBuilder.Entity<DeviceData>().HasOne(d => d.Device).WithMany(d => d.DevicesData).HasPrincipalKey(ug => ug.DeviceGuid).HasForeignKey(u => u.DeviceGuid).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WeatherDeviceData>().HasOne(d => d.Device).WithMany(d => d.WeatherDevicesData).HasPrincipalKey(ug => ug.DeviceGuid).HasForeignKey(u => u.DeviceGuid).OnDelete(DeleteBehavior.Cascade);

            // Device AI
            modelBuilder.Entity<DataAI>().HasOne(d => d.DeviceData).WithMany(d => d.DataAIs).HasForeignKey(u => u.DataGuid).OnDelete(DeleteBehavior.Cascade);
            // Device AO
            modelBuilder.Entity<DataAO>().HasOne(d => d.DeviceData).WithMany(d => d.DataAOs).HasForeignKey(u => u.DataGuid).OnDelete(DeleteBehavior.Cascade);
            // Device DI
            modelBuilder.Entity<DataDI>().HasOne(d => d.DeviceData).WithMany(d => d.DataDIs).HasForeignKey(u => u.DataGuid).OnDelete(DeleteBehavior.Cascade);
            // Device AO
            modelBuilder.Entity<DataDO>().HasOne(d => d.DeviceData).WithMany(d => d.DataDOs).HasForeignKey(u => u.DataGuid).OnDelete(DeleteBehavior.Cascade);
            // Device Metadata
            modelBuilder.Entity<DataMEATADATA>().HasOne(d => d.DeviceData).WithMany(d => d.DataMetadatas).HasForeignKey(u => u.DataGuid).OnDelete(DeleteBehavior.Cascade);

            //CanEdit relationship

            //device Configuration table
            modelBuilder.Entity<DeviceConfig>().ToTable("DeviceConfig");
            modelBuilder.Entity<DeviceConfig>().HasOne(d => d.Device).WithMany(d => d.DevicesConfig).HasPrincipalKey(ug => ug.DeviceGuid).HasForeignKey(u => u.DeviceGuid).OnDelete(DeleteBehavior.Cascade);

            //device Configuration table
            modelBuilder.Entity<DeviceConfig>().ToTable("DeviceConfig");
            modelBuilder.Entity<DeviceConfig>().HasOne(d => d.Device).WithMany(d => d.DevicesConfig).HasPrincipalKey(ug => ug.DeviceGuid).HasForeignKey(u => u.DeviceGuid).OnDelete(DeleteBehavior.Cascade);
            
            //device Configuration table
            modelBuilder.Entity<DeviceConfigItem>().ToTable("DeviceConfigItem");
            modelBuilder.Entity<DeviceConfigItem>().HasOne(d => d.Device).WithMany(d => d.DevicesConfigItem).HasPrincipalKey(ug => ug.DeviceGuid).HasForeignKey(u => u.DeviceGuid).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ParamName>().ToTable("ParamName");
            modelBuilder.Entity<ParamName>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<ParamName>().HasMany(d => d.Devices).WithMany(u => u.ParamNames);            
            modelBuilder.Entity<ParamName>().HasKey(u => u.Id).HasName("PK_ParamName");
            //device user table
            //modelBuilder.Entity<DeviceUser>().ToTable("DeviceUser");
            //modelBuilder.Entity<DeviceUser>().HasKey(c => new { c.DevicesDeviceGuid, c.UsersUserGuid });
        }
    }
}
