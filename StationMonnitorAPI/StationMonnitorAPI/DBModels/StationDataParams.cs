using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace StationMonnitorAPI.DBModels
{
    public class StationDataParam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Param { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }

    }
}
