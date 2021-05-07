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
        private readonly ILogger<Marae> _logger;
        private IMaraeProvider maraeProvider;
        private IMaraeUpdater maraeUpdater;

        public NgaMaraeController(ILogger<Marae> logger, IMaraeProvider provider, IMaraeUpdater updater)
        {
            _logger = logger;
            maraeProvider = provider;
            maraeUpdater = updater;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string orderby, string searchString)
        {
            var ngamarae = await maraeProvider.GetAllMaraeAsync(orderby, searchString);
            return Ok(ngamarae);
        }

        [HttpGet("[controller]/area/{areaname}")]
        public async Task<IActionResult> GetByAreaNameAsync(string areaname, string sortby, string searchString)
        {
            var ngamarae = await maraeProvider.GetAllMaraeByAreaAsync(areaname, sortby, searchString);
            return Ok(ngamarae);
        }

        [HttpGet("[controller]/hapu/{hapuname}")]
        public async Task<IActionResult> GetByHapuNameAsync(string hapuname, string sortby, string searchString)
        {
            var ngamarae = await maraeProvider.GetAllMaraeByHapuAsync(hapuname, sortby, searchString);
            return Ok(ngamarae);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ngamarae = await maraeProvider.GetMaraeByIdAsync(id);
            return Ok(ngamarae);
        }

        [HttpPost("[controller]/")]
        public async Task<IActionResult> GetByIdAsync(Marae newMarae)
        {
            var marae = await maraeUpdater.CreateMaraeAsync(newMarae);
            return Ok(marae);
        }

        [HttpPut("[controller]/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, string area = "", string maraeName = "", string hapu = "")
        {
            var marae = await maraeUpdater.UpdateMaraeAsync(id, area, maraeName, hapu);
            return Ok(marae);
        }
    }
}