using System;
using System.Collections.Generic;
using System.Text;

namespace HamuaHapuCommon.Resources
{
    public class TupunaResource
    {
        public int TupunaId { get; set; }
        public TangataResource Uri { get; set; }
        public string Name { get; set; }
        public string PrimaryIwi { get; set; }
        public string PrimaryHapu { get; set; }
        public string Relationship { get; set; }
    }
}