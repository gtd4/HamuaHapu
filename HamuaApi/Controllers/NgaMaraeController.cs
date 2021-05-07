using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HamuaRegistrationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NgaMaraeController : ControllerBase
    {
        private readonly ILogger<NgaMarae> _logger;
        private IMaraeProvider maraeProvider;

        public NgaMaraeController(ILogger<NgaMarae> logger, IMaraeProvider provider)
        {
            _logger = logger;
            maraeProvider = provider;
        }

        [HttpGet]
        public IEnumerable<NgaMarae> Get(string orderby, string searchString)
        {
            var ngamarae = maraeProvider.GetAllMarae(orderby, searchString);
            return ngamarae;
        }

        [HttpGet("[controller]/area/{areaname}")]
        public IEnumerable<NgaMarae> GetByAreaName(string areaname, string sortby, string searchString)
        {
            var ngamarae = maraeProvider.GetAllOrdersByArea(areaname, sortby, searchString);
            return ngamarae;
        }

        [HttpGet("[controller]/hapu/{hapuname}")]
        public IEnumerable<NgaMarae> GetByHapuName(string hapuname, string sortby, string searchString)
        {
            var ngamarae = maraeProvider.GetAllOrdersByHapu(hapuname, sortby, searchString);
            return ngamarae;
        }

        [HttpGet("[controller]/{id}")]
        public NgaMarae GetById(int id)
        {
            var marae = maraeProvider.GetMaraeById(id);
            return marae;
        }
    }
}