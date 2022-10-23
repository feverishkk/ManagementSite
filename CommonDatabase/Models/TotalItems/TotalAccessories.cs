﻿using CommonDatabase.Models.Accessories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class TotalAccessories
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Damage { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
