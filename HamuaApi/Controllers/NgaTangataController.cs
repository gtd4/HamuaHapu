using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Interfaces;
using HamuaRegistrationApi.Extensions;
using HamuaRegistrationApi.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HamuaRegistrationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NgaTangataController : ControllerBase
    {
        private readonly ILogger<Marae> _logger;
        private ITangataService tangataService;
        private ITangataUpdater tangataUpdater;
        private IMapper tangataMapper;

        public NgaTangataController(ILogger<Marae> logger, ITangataService service, ITangataUpdater updater, IMapper mapper)
        {
            _logger = logger;
            tangataService = service;
            tangataUpdater = updater;
            tangataMapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string orderby, string searchString, bool include)
        {
            var ngaTangata = await tangataService.GetAllTangataAsync(orderby, searchString, include);
            var resources = tangataMapper.Map<IEnumerable<Tangata>, IEnumerable<TangataResource>>(ngaTangata);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, bool include)
        {
            var ngaTangata = await tangataService.GetTangataByIdAsync(id, include);
            return Ok(ngaTangata);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateTangataAsync([FromBody] CreateTangataResource newTangata)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tangata = tangataMapper.Map<CreateTangataResource, Tangata>(newTangata);
            var marae = newTangata.NgaMaraeList;

            //ToDo: Investigate how many to many relationships work
            var result = await tangataService.CreateTangataAsync(tangata, marae);

            if (!result.Success)
                return BadRequest(result.Message);

            var tangataResource = tangataMapper.Map<Tangata, TangataResource>(result.Tangata);
            return Ok(tangataResource);
        }

        [HttpPost("{parentId}/child")]
        public async Task<IActionResult> CreateChildAsync([FromBody] Tangata newTangata, int parentId)
        {
            //ToDo: Investigate how many to many relationships work

            var tangata = await tangataService.AddChild(newTangata, parentId);
            return Ok(tangata);
        }

        [HttpPost("{childId}/parent")]
        public async Task<IActionResult> CreateParentAsync([FromBody] Tangata newTangata, int parentId)
        {
            //ToDo: Investigate how many to many relationships work

            var tangata = await tangataService.AddChild(newTangata, parentId);
            return Ok(tangata);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTangataAsync(int id, string firstName = "", string lastname = "")
        {
            var tangata = await tangataService.UpdateTangataAsync(id, firstName, lastname);
            return Ok(tangata);
        }
    }
}