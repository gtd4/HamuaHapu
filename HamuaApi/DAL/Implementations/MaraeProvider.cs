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

        public IEnumerable<NgaMarae> GetAllMarae(string sortby, string searchString = "")
        {
            var marae = maraeContext.NgaMarae.Select(x => x);

            if (!string.IsNullOrEmpty(searchString))
            {
                marae = marae.Where(x => x.Area.Contains(searchString) || x.Hapu.Contains(searchString) || x.Marae.Contains(searchString));
            }

            switch (sortby)
            {
                case "marae_desc":
                    marae = marae.OrderByDescending(s => s.Marae);
                    break;

                case "hapu":
                    marae = marae.OrderBy(s => s.Hapu);
                    break;

                case "hapu_desc":
                    marae = marae.OrderByDescending(s => s.Hapu);
                    break;

                default:
                    marae = marae.OrderBy(s => s.Marae);
                    break;
            }
            return marae;
        }

        public IEnumerable<NgaMarae> GetAllOrdersByArea(string areaName, string sortby, string searchString = "")
        {
            var marae = GetAllMarae(sortby, searchString);

            return marae.Where(x => x.Area.Equals(areaName)); ;
        }

        public IEnumerable<NgaMarae> GetAllOrdersByHapu(string hapuName, string sortby, string searchString = "")
        {
            var marae = GetAllMarae(sortby, searchString);

            return marae.Where(x => x.Hapu.Equals(hapuName)); ;
        }
    }
}