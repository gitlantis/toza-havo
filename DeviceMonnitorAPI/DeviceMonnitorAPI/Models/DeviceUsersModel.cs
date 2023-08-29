﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceMonnitorAPI.Models
{
    public class DeviceUsersModel
    {
        public Guid[] UserGuid{get;set;}
        public Guid DeviceGuid{get;set;}  
        public bool[] CanEdit { get; set; }
    }
}
