using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations

{
    public class TangataUpdater : ITangataUpdater
    {
        private HamuaContext maraeContext;
        private IMaraeProvider maraeProvider;

        public TangataUpdater(HamuaContext context, IMaraeProvider provider)
        {
            maraeContext = context;
            maraeProvider = provider;
        }
    }
}