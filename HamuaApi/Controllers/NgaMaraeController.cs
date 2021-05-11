using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Interfaces;
using HamuaRegistrationApi.Resources;
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
        private IMapper maraeMapper;

        public NgaMaraeController(ILogger<Marae> logger, IMaraeService service, IMaraeUpdater updater, IMapper mapper)
        {
            _logger = logger;
            maraeService = service;
            maraeUpdater = updater;
            maraeMapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string orderby, string searchString, bool include)
        {
            var ngamarae = await maraeService.GetAllMaraeAsync(orderby, searchString, include);

            if (include)
            {
                return Ok(ngamarae);
            }

            var resources = maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResource>>(ngamarae);
            return Ok(resources);
        }

        [HttpGet("area/{areaname}")]
        public async Task<IActionResult> GetByAreaNameAsync(string areaname, string sortby, string searchString, bool include)
        {
            var ngamarae = await maraeService.GetAllMaraeByAreaAsync(areaname, sortby, searchString, include);

            if (include)
            {
                return Ok(ngamarae);
            }

            var resources = maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResource>>(ngamarae);

            return Ok(resources);
        }

        [HttpGet("hapu/{hapuname}")]
        public async Task<IActionResult> GetByHapuNameAsync(string hapuname, string sortby, string searchString, bool include)
        {
            var ngamarae = await maraeService.GetAllMaraeByHapuAsync(hapuname, sortby, searchString, include);

            if (include)
            {
                return Ok(ngamarae);
            }

            var resources = maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResource>>(ngamarae);

            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, bool include)
        {
            var ngamarae = await maraeService.GetMaraeByIdAsync(id, include);

            if (include)
            {
                return Ok(ngamarae);
            }

            var resource = maraeMapper.Map<Marae, MaraeResource>(ngamarae);

            return Ok(resource);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateMaraeAsync(Marae newMarae)
        {
            var marae = await maraeService.CreateMaraeAsync(newMarae);
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