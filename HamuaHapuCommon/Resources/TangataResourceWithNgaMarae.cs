using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuCommon.Resources
{
    public class TangataResourceWithNgaMarae : TangataResource
    {
        public IEnumerable<MaraeResource> NgaMarae { get; set; }
    }
}