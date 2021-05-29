using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HamuaHapuCommon.Resources
{
    public class SaveTupunaResource
    {
        public string Name { get; set; }

        public string PrimaryIwi { get; set; }

        public string PrimaryHapu { get; set; }

        public string Relationship { get; set; }
    }
}