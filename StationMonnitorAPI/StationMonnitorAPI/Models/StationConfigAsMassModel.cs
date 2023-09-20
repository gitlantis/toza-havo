using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonnitorAPI.Models
{
    public class StationConfigAsMassModel
    {
        public decimal[] AI { get; set; }
        public bool[] DO { get; set; }
    }
}