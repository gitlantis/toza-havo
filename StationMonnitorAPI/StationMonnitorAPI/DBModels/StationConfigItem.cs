using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonnitorAPI.DBModels
{
    public class StationConfigItem
    {
        [Key]
        public Guid ConfGuid { get; set; }
        public Guid StationGuid { get; set; }
        
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        
        public virtual Station Station { get; set; }
    }
}

