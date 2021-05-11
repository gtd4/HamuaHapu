using HamuaRegistrationApi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HamuaContext _context;

        public UnitOfWork(HamuaContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}