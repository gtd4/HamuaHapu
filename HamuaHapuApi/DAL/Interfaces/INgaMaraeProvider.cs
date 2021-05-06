using HamuaHapuApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuApi.DAL.Interfaces
{
    public interface INgaMaraeProvider
    {
        IEnumerable<NgaMarae> GetAllMarae();
    }
}