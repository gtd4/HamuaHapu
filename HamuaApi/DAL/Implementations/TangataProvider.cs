using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations

{
    public class TangataProvider : ITangataProvider
    {
        private HamuaContext tangataContext;

        public TangataProvider(HamuaContext context)
        {
            tangataContext = context;
        }
    }
}