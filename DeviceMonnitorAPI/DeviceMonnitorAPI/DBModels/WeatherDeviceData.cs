using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceMonnitorAPI.DBModels
{
    public class WeatherDeviceData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid DeviceGuid { get; set; }
        public double Co { get; set; }
        public double Co2 { get; set; }
        public double Pm1 { get; set; }
        public double Pm2_5 { get; set; }
        public double Pm10 { get; set; }
        public double Aqi { get; set; }
        public double Humadity { get; set; }
        public double SandHumadity { get; set; }
        public double Temperature { get; set; }
        public double SandTemperature { get; set; }
        public double SandElectric { get; set; }
        public double SandSalt { get; set; }
        public double SandSaltElectric { get; set; }
        public double Rain { get; set; }
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }

        public DateTime DeviceDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }

        public virtual Device Device { get; set; }
    }
}