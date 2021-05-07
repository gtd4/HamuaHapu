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
            //var ngamarae = await tangataProvider.GetAllTangataAsync(orderby, searchString);
            //return Ok(ngamarae);
            return Ok();
        }

        [HttpGet("[controller]/area/{areaname}")]
        public async Task<IActionResult> GetByAreaNameAsync(string areaname, string sortby, string searchString)
        {
            //var ngamarae = await tangataProvider.GetAllTangataByAreaAsync(areaname, sortby, searchString);
            //return Ok(ngamarae);
            return Ok();
        }

        [HttpGet("[controller]/hapu/{hapuname}")]
        public async Task<IActionResult> GetByHapuNameAsync(string hapuname, string sortby, string searchString)
        {
            //var ngamarae = await tangataProvider.GetAllTangataByHapuAsync(hapuname, sortby, searchString);
            //return Ok(ngamarae);
            return Ok();
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            //var ngamarae = await tangataProvider.GetTangataByIdAsync(id);
            //return Ok(ngamarae);
            return Ok();
        }

        [HttpPost("[controller]/")]
        public async Task<IActionResult> GetByIdAsync(Tangata newTangata)
        {
            //var tangata = await tangataUpdater.CreateTangataAsync(newTangata);
            //return Ok(tangata);
            return Ok();
        }

        [HttpPut("[controller]/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, string area = "", string maraeName = "", string hapu = "")
        {
            //var marae = await tangataUpdater.UpdateTangataAsync(id, area, maraeName, hapu);
            //return Ok(marae);
            return Ok();
        }
    }
}