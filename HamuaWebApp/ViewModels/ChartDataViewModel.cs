using HamuaHapuCommon.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuRegistration.ViewModels
{
    public class ChartDataViewModel
    {
        public string Title { get; set; }
        public IEnumerable<IGrouping<string, TangataResource>> Tangata { get; set; }
        public Dictionary<string, int> ChartData { get; set; } = new Dictionary<string, int>();
    }
}