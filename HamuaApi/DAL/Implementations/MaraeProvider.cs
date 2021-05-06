using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations

{
    public class MaraeProvider : IMaraeProvider
    {
        private HamuaContext maraeContext;

        public MaraeProvider(HamuaContext context)
        {
            maraeContext = context;
        }

        public IEnumerable<NgaMarae> GetAllOrders()
        {
            return maraeContext.NgaMarae;
        }
    }
}