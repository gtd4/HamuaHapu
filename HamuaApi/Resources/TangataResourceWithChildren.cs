using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.Resources
{
    public class TangataResourceWithChildren : TangataResource
    {
        public IEnumerable<TangataResource> Children { get; set; } = new List<TangataResource>();
    }
}