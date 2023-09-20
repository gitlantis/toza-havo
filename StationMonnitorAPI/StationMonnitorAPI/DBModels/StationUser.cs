using System;
using System.ComponentModel.DataAnnotations;

namespace StationMonnitorAPI.DBModels
{
    public class StationUser
    {
        public Guid StationsStationGuid { get; set; }
        public Guid UsersUserGuid { get; set; }
        public bool CanEdit { get; set; } = false;
    }
}
