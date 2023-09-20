using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonnitorAPI.Models
{
    public class StationUsersModel
    {
        public Guid[] UserGuid{get;set;}
        public Guid StationGuid{get;set;}  
        public bool[] CanEdit { get; set; }
    }
}
