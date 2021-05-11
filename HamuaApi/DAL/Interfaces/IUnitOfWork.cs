using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}