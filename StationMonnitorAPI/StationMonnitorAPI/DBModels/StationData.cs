﻿using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DataAnnotation = ServiceStack.DataAnnotations;

namespace StationMonnitorAPI.DBModels
{
    public class StationData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid StationGuid { get; set; }
        public double? A00 { get; set; }
        public double? A01 { get; set; }
        public double? A02 { get; set; }
        public double? A03 { get; set; }
        public double? A04 { get; set; }
        public double? A05 { get; set; }
        public double? A06 { get; set; }
        public double? A07 { get; set; }
        public double? A08 { get; set; }
        public double? A09 { get; set; }
        public double? A10 { get; set; }
        public double? A11 { get; set; }
        public double? A12 { get; set; }
        public double? A13 { get; set; }
        public double? A14 { get; set; }
        public double? A15 { get; set; }
        public double? A16 { get; set; }
        public double? A17 { get; set; }
        public double? A18 { get; set; }
        public double? A19 { get; set; }
        public double? A20 { get; set; }
        public double? A21 { get; set; }
        public double? A22 { get; set; }
        public double? A23 { get; set; }
        public double? A24 { get; set; }
        public double? A25 { get; set; }
        public double? A26 { get; set; }
        public double? A27 { get; set; }
        public double? A28 { get; set; }
        public double? A29 { get; set; }
        public double? A30 { get; set; }
        public double? A31 { get; set; }
        public DateTime StationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }

        public virtual Station Station { get; set; }
    }
}