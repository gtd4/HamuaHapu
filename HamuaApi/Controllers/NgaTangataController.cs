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
    public class NgaTangataController : ControllerBase
    {
        private readonly ILogger<Marae> _logger;
        private ITangataService tangataService;
        private ITangataUpdater tangataUpdater;

        public NgaTangataController(ILogger<Marae> logger, ITangataService service, ITangataUpdater updater)
        {
            _logger = logger;
            tangataService = service;
            tangataUpdater = updater;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string orderby, string searchString, bool include)
        {
            var ngaTangata = await tangataService.GetAllTangataAsync(orderby, searchString, include);
            return Ok(ngaTangata);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, bool include)
        {
            var ngaTangata = await tangataService.GetTangataByIdAsync(id, include);
            return Ok(ngaTangata);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateTangataAsync([FromBody] Tangata newTangata)
        {
            //ToDo: Investigate how many to many relationships work
            var tangata = await tangataService.CreateTangataAsync(newTangata);
            return Ok(tangata);
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