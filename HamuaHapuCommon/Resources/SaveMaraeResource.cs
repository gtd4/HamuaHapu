﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuCommon.Resources
{
    public class SaveMaraeResource
    {
        [Required]
        public string Area { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Hapu { get; set; }
    }
}