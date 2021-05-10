using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HamuaRegistrationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NgaMaraeController : ControllerBase
    {
        private readonly ILogger<Marae> _logger;
        private IMaraeService maraeService;
        private IMaraeUpdater maraeUpdater;

        public NgaMaraeController(ILogger<Marae> logger, IMaraeService service, IMaraeUpdater updater)
        {
            _logger = logger;
            maraeService = service;
            maraeUpdater = updater;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string orderby, string searchString, bool include)
        {
            var ngamarae = await maraeService.GetAllMaraeAsync(orderby, searchString, include);
            return Ok(ngamarae);
        }

        [HttpGet("area/{areaname}")]
        public async Task<IActionResult> GetByAreaNameAsync(string areaname, string sortby, string searchString, bool include)
        {
            var ngamarae = await maraeService.GetAllMaraeByAreaAsync(areaname, sortby, searchString, include);
            return Ok(ngamarae);
        }

        [HttpGet("hapu/{hapuname}")]
        public async Task<IActionResult> GetByHapuNameAsync(string hapuname, string sortby, string searchString, bool include)
        {
            var ngamarae = await maraeService.GetAllMaraeByHapuAsync(hapuname, sortby, searchString, include);
            return Ok(ngamarae);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, bool include)
        {
            var ngamarae = await maraeService.GetMaraeByIdAsync(id, include);
            return Ok(ngamarae);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateMaraeAsync(Marae newMarae)
        {
            var marae = await maraeUpdater.CreateMaraeAsync(newMarae);
            return Ok(marae);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaraeAsync(int id, string area = "", string maraeName = "", string hapu = "")
        {
            var marae = await maraeUpdater.UpdateMaraeAsync(id, area, maraeName, hapu);
            return Ok(marae);
        }
    }
}