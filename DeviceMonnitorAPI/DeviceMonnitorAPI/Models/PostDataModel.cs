using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceMonnitorAPI.Models
{
    public class PostDataModel
    {        
        public string secret { get; set; }        
        public string dev_guid { get; set; }
        public double co { get; set; }
        public double co2 { get; set; }
        public double pm1 { get; set; }
        public double pm2_5 { get; set; }
        public double pm10 { get; set; }
        public double aqi { get; set; }
        public double hum { get; set; }
        public double sand_hum { get; set; }
        public double temp { get; set; }
        public double sand_temp { get; set; }
        public double sand_elec { get; set; }
        public double sand_salt { get; set; }
        public double sand_selec { get; set; }
        public double rain { get; set; }
        public double wind_s { get; set; }
        public double wind_d { get; set; }
        public DateTime? date { get; set; }
    }
}
