﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpyStore.Models.Entities.Base
{
    public class OrderDetailBase : EntityBase
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, DataType(DataType.Currency), Display(Name = "Unit Cost")]
        public decimal UnitCost { get; set; }
    }
}
