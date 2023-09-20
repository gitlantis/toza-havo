﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonnitorAPI.Models
{
    public class ChildDataWithParam
    {
        public int ParamIndex { get; set; }
        public int ParamOrder { get; set; }
        public string ParamName { get; set; }
        public string ParamDesc { get; set; }
        public string ParamSubDomain { get; set; }
        public dynamic Params { get; set; }
    }
}
