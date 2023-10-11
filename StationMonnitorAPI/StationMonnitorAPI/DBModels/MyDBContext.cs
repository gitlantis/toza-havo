using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace StationMonnitorAPI.DBModels
{
    public class MyDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<StationData> StationData { get; set; }
        public DbSet<StationDataParam> StationDataParam { get; set; }
        public DbSet<StationConfig> StationConfig { get; set; }
        public DbSet<StationConfigItem> StationConfigItem { get; set; }
        public DbSet<ParamName> ParamNames { get; set; }
        public DbSet<StationUser> StationUsers { get; set; }


        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().HasMany(d => d.Stations).WithMany(u => u.Users);
            // Configure Primary Keys  
            modelBuilder.Entity<User>().HasKey(u => u.UserGuid).HasName("PK_Users");
            modelBuilder.Entity<User>().HasData(
                new User { UserGuid = Guid.NewGuid(), FirstName = "Api", LastName = "Admin", Username = "apiadmin", Password = "@p!Adm!n21U$er00222", IsActive = true, Role = "ApiAdmin", CreatedDate = DateTime.Now },
                new User { UserGuid = Guid.NewGuid(), FirstName = "Admin", LastName = "User", Username = "admin", Password = "@@dm!nU$er", IsActive = true, Role = "Admin", CreatedDate = DateTime.Now },
                new User { UserGuid = Guid.NewGuid(), FirstName = "Station", LastName = "User", Username = "station", Password = "_MyP0werfulDev!ce", IsActive = true, Role = "Station", CreatedDate = DateTime.Now }
                );

            // Map entities to tables  
            modelBuilder.Entity<Station>().ToTable("Stations");
            modelBuilder.Entity<Station>().HasKey(u => u.StationGuid).HasName("PK_Station");
            modelBuilder.Entity<Station>().HasMany(u => u.Users).WithMany(d => d.Stations)
                .UsingEntity<StationUser>(
                l => l.HasOne<User>().WithMany().HasForeignKey(e => e.UsersUserGuid),
                r => r.HasOne<Station>().WithMany().HasForeignKey(e => e.StationsStationGuid));

            // Map entities to tables  
            modelBuilder.Entity<StationData>().ToTable("StationData");
            modelBuilder.Entity<StationData>().HasOne(d => d.Station).WithMany(d => d.StationsData).HasPrincipalKey(ug => ug.StationGuid).HasForeignKey(u => u.StationGuid).OnDelete(DeleteBehavior.Cascade);

            var weatherData = new StationData();
            modelBuilder.Entity<StationDataParam>().ToTable("StationDataParams").HasData(
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A00), Name = "AirTemperature", Description = "Air temperature" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A01), Name = "AirHumadity", Description = "Air humadity" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A02), Name = "AirPM1_0", Description = "Air dist PM1.0" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A03), Name = "AirPM2_5", Description = "Air dist PM2.5" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A04), Name = "AirPM10_", Description = "Air dist PM10" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A05), Name = "AQI", Description = "AQI" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A06), Name = "AirPMAdd2", Description = "AirPMAdd2" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A07), Name = "AirPMAdd3", Description = "AirPMAdd3" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A08), Name = "AirPMAdd4", Description = "AirPMAdd4" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A09), Name = "AirPMAdd5", Description = "AirPMAdd5" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A10), Name = "AirPMAdd6", Description = "AirPMAdd6" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A11), Name = "AirPMAdd7", Description = "AirPMAdd7" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A12), Name = "AirPMAdd8", Description = "AirPMAdd8" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A13), Name = "AirPMAdd9", Description = "AirPMAdd9" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A14), Name = "gasCO2ppm", Description = "Gas CO2" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A15), Name = "gasCOppm", Description = "Gas CO" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A16), Name = "soilConductivity", Description = "Soil conductivity" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A17), Name = "soilTemperature", Description = "Soil temperature" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A18), Name = "soilHumadity", Description = "Soil humadity" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A19), Name = "soilSaliness", Description = "Soil salting" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A20), Name = "windSpeed", Description = "Wind speed m/s" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A21), Name = "windDeirection", Description = "Wind direction" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A22), Name = "leafTmeperature", Description = "Leaf temperature" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A23), Name = "leafumadity", Description = "Leaf humadity" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A24), Name = "gpsLang", Description = "Langitude" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A25), Name = "gpsLat", Description = "Latitude" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A26), Name = "gpsAlt", Description = "Altitude" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A27), Name = "accVoltage", Description = "Accumulator voltage" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A28), Name = "pressure", Description = "Air pressure" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A29), Name = "radiation", Description = "Solar radiation" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A30), Name = "reserve03", Description = "Reserve03" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.A31), Name = "reserve04", Description = "Reserve04" },                
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.StationDate), Name = "StationDate", Description = "Stations information date" },
                new StationDataParam { Id = Guid.NewGuid(), Param = nameof(weatherData.CreatedDate), Name = "CreatedDate", Description = "Stations information created date" }
                );

            //station Configuration table
            modelBuilder.Entity<StationConfig>().ToTable("StationConfig");
            modelBuilder.Entity<StationConfig>().HasOne(d => d.Station).WithMany(d => d.StationsConfig).HasPrincipalKey(ug => ug.StationGuid).HasForeignKey(u => u.StationGuid).OnDelete(DeleteBehavior.Cascade);
            
            //station Configuration table
            modelBuilder.Entity<StationConfigItem>().ToTable("StationConfigItem");
            modelBuilder.Entity<StationConfigItem>().HasOne(d => d.Station).WithMany(d => d.StationsConfigItem).HasPrincipalKey(ug => ug.StationGuid).HasForeignKey(u => u.StationGuid).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ParamName>().ToTable("ParamName");
            modelBuilder.Entity<ParamName>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<ParamName>().HasMany(d => d.Stations).WithMany(u => u.ParamNames);            
            modelBuilder.Entity<ParamName>().HasKey(u => u.Id).HasName("PK_ParamName");
            //station user table
            //modelBuilder.Entity<StationUser>().ToTable("StationUser");
            //modelBuilder.Entity<StationUser>().HasKey(c => new { c.StationsStationGuid, c.UsersUserGuid });
        }
    }
}
