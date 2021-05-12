using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuCommon.Resources
{
    public class TangataResourceWithNgaMaraeChildren : TangataResource
    {
        public IEnumerable<MaraeResource> NgaMarae { get; set; } = new List<MaraeResource>();
        public IEnumerable<TangataResource> Children { get; set; } = new List<TangataResource>();
    }
}