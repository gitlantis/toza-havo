using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceMonnitorAPI.DBModels
{
    public class DeviceData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid DeviceGuid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public virtual Device Device { get; set; }
        public virtual ICollection<DataAI> DataAIs { get; set; }
        public virtual ICollection<DataAO> DataAOs { get; set; }
        public virtual ICollection<DataDI> DataDIs { get; set; }
        public virtual ICollection<DataDO> DataDOs { get; set; }
        public virtual ICollection<DataMEATADATA> DataMetadatas { get; set; }
    }
}