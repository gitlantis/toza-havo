using System;
using System.ComponentModel.DataAnnotations;

namespace DeviceMonnitorAPI.DBModels
{
    public class DeviceUser
    {
        public Guid DevicesDeviceGuid { get; set; }
        public Guid UsersUserGuid { get; set; }
        public bool CanEdit { get; set; } = false;
    }
}
