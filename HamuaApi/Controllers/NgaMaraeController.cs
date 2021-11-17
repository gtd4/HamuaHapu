using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HamuaHapuCommon.Resources;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Interfaces;
using HamuaRegistrationApi.Extensions;
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

        private IMapper maraeMapper;

        public NgaMaraeController(ILogger<Marae> logger, IMaraeService service, IMapper mapper)
        {
            _logger = logger;
            maraeService = service;

            maraeMapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string orderby, string searchString, bool includeTangata)
        {
            try
            {
                var ngamarae = await maraeService.GetAllMaraeAsync(orderby, searchString, includeTangata);

                if (includeTangata)
                {
                    return Ok(maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResourceWithNgaTangata>>(ngamarae));
                }

                return Ok(maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResource>>(ngamarae));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("area/{areaname}")]
        public async Task<IActionResult> GetByAreaNameAsync(string areaname, string sortby, string searchString, bool includeTangata)
        {
            var ngamarae = await maraeService.GetAllMaraeByAreaAsync(areaname, sortby, searchString, includeTangata);

            if (includeTangata)
            {
                return Ok(maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResourceWithNgaTangata>>(ngamarae));
            }

            var resources = maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResource>>(ngamarae);

            return Ok(resources);
        }

        [HttpGet("hapu/{hapuname}")]
        public async Task<IActionResult> GetByHapuNameAsync(string hapuname, string sortby, string searchString, bool includeTangata)
        {
            var ngamarae = await maraeService.GetAllMaraeByHapuAsync(hapuname, sortby, searchString, includeTangata);

            if (includeTangata)
            {
                return Ok(maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResourceWithNgaTangata>>(ngamarae));
            }

            var resources = maraeMapper.Map<IEnumerable<Marae>, IEnumerable<MaraeResource>>(ngamarae);

            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaraeByIdAsync(int id, bool includeTangata)
        {
            var ngamarae = await maraeService.GetMaraeByIdAsync(id, includeTangata);

            if (includeTangata)
            {
                return Ok(maraeMapper.Map<Marae, MaraeResourceWithNgaTangata>(ngamarae));
            }

            var resource = maraeMapper.Map<Marae, MaraeResource>(ngamarae);

            return Ok(resource);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateMaraeAsync([FromBody] SaveMaraeResource newMarae)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var marae = maraeMapper.Map<SaveMaraeResource, Marae>(newMarae);

            //ToDo: Investigate how many to many relationships work
            var result = await maraeService.CreateMaraeAsync(marae);

            if (!result.Success)
                return BadRequest(result.Message);

            var maraeResource = maraeMapper.Map<Marae, MaraeResource>(result.Marae);
            return Created(nameof(GetMaraeByIdAsync), maraeResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaraeAsync(int id, [FromBody] SaveMaraeResource editMarae)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var marae = maraeMapper.Map<SaveMaraeResource, Marae>(editMarae);
            var result = await maraeService.UpdateMaraeAsync(id, marae);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = maraeMapper.Map<Marae, MaraeResource>(result.Marae);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await maraeService.DeleteMaraeAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var maraeResource = maraeMapper.Map<Marae, MaraeResource>(result.Marae);
            return Ok(maraeResource);
        }
    }
}