using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuCommon.Resources
{
    public class MaraeResourceWithNgaTangata : MaraeResource
    {
        public IEnumerable<TangataResource> NgaTangata { get; set; } = new List<TangataResource>();
    }
}