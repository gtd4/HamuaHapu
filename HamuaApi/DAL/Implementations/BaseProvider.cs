using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations
{
    public abstract class BaseProvider
    {
        protected readonly HamuaContext hamuaContext;

        public BaseProvider(HamuaContext context)
        {
            hamuaContext = context;
        }
    }
}