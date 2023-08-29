﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetwayAndAPI.Models
{
    public class Device
    {
        public Guid DeviceGuid {get;set;}
        public string Name {get;set;}        
        public string Description { get; set; }
        public bool IsActive { get; set; }        
    }
}
