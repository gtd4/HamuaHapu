using HamuaHapuCommon.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuRegistration.ViewModels
{
    public class RegisterViewModel
    {
        public SaveTangataResource Member { get; set; } = new SaveTangataResource();
        public IEnumerable<IGrouping<string, MaraeResource>> NgaMaraeGoup { get; set; }
    }
}