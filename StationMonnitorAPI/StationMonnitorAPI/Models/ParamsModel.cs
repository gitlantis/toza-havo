using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonnitorAPI.Models
{
    public class ParamsModel
    {
        public Guid StationGUID { get; set; }
        public List<SingleParamModel> Params { get; set; }
    }

}