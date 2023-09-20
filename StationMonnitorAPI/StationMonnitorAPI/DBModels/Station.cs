using Microsoft.AspNetCore.Mvc;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace StationMonnitorAPI.DBModels
{
    public class Station
    {
        [Key]
        public Guid StationGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<StationData> StationsData { get; set; }
        public virtual ICollection<StationConfig> StationsConfig { get; set; }
        public virtual ICollection<StationConfigItem> StationsConfigItem { get; set; }
        public virtual ICollection<ParamName> ParamNames { get; set; }
        public virtual ICollection<StationUser> StationUsers { get; set; }
    }
}
