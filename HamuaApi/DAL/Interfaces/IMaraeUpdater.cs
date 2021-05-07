﻿using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Interfaces

{
    public interface IMaraeUpdater
    {
        Task<NgaMarae> CreateMaraeAsync(NgaMarae newMarae);

        Task<NgaMarae> UpdateMaraeAsync(int id, string area, string maraeName, string hapu);

        Task<NgaMarae> DeleteMaraeAsync(int id);
    }
}