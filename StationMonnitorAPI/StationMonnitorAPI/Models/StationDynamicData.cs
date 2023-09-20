using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonnitorAPI.Models
{
    public class StationDynamicData
    {
        public Guid StationGuid { get; set; }
        public string Name { get; set; }
        public DateTime LastDataTime { get; set; }
        public bool IsWorking { get; set; }
        public bool IsActive { get; set; }
        public int RowCount { get; set; }
        public List<ChildDataWithParam> AI { get; set; }        
        public List<ChildDataWithParam> DI { get; set; }        
        public List<ChildDataWithParam> Metadata { get; set; }        
    }
}
