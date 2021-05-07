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
    public class NgaTangataController : ControllerBase
    {
        private readonly ILogger<Marae> _logger;
        private ITangataProvider tangataProvider;
        private ITangataUpdater tangataUpdater;

        public NgaTangataController(ILogger<Marae> logger, ITangataProvider provider, ITangataUpdater updater)
        {
            _logger = logger;
            tangataProvider = provider;
            tangataUpdater = updater;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string orderby, string searchString)
        {
            var ngaTangata = await tangataProvider.GetAllTangataAsync(orderby, searchString);
            return Ok(ngaTangata);
        }

        //[HttpGet("[controller]/area/{areaname}")]
        //public async Task<IActionResult> GetByAreaNameAsync(string areaname, string sortby, string searchString)
        //{
        //    //var ngamarae = await tangataProvider.GetAllTangataByAreaAsync(areaname, sortby, searchString);
        //    //return Ok(ngamarae);
        //    return Ok();
        //}

        //[HttpGet("[controller]/hapu/{hapuname}")]
        //public async Task<IActionResult> GetByHapuNameAsync(string hapuname, string sortby, string searchString)
        //{
        //    //var ngamarae = await tangataProvider.GetAllTangataByHapuAsync(hapuname, sortby, searchString);
        //    //return Ok(ngamarae);
        //    return Ok();
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ngaTangata = await tangataProvider.GetTangataByIdAsync(id);
            return Ok(ngaTangata);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateTangataAsync([FromBody] Tangata newTangata)
        {
            //ToDo: Investigate how many to many relationships work
            var tangata = await tangataUpdater.CreateTangataAsync(newTangata);
            return Ok(tangata);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTangataAsync(int id, string firstName = "", string lastname = "")
        {
            var tangata = await tangataUpdater.UpdateTangataAsync(id, firstName, lastname);
            return Ok(tangata);
        }
    }
}