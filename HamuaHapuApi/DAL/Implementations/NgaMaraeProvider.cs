using HamuaHapuApi.DAL.Interfaces;
using HamuaHapuApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuApi.DAL.Implementations
{
    public class NgaMaraeProvider : INgaMaraeProvider
    {
        private HamuaContext _hamuaContext;

        public NgaMaraeProvider(HamuaContext context)
        {
            _hamuaContext = context;
        }

        public IEnumerable<NgaMarae> GetAllMarae()
        {
            return _hamuaContext.NgaMarae;
        }
    }
}