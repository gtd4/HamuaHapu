using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using HamuaHapuApi.DAL.Interfaces;
using HamuaHapuApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;

namespace HamuaHapuApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NgaMaraeController : ControllerBase
    {
        private readonly ILogger<NgaMaraeController> _logger;
        private INgaMaraeProvider maraeProvider;

        public NgaMaraeController(ILogger<NgaMaraeController> logger, INgaMaraeProvider ngaMaraeProvider)
        {
            _logger = logger;
            maraeProvider = ngaMaraeProvider;
        }

        [HttpGet]
        public IEnumerable<NgaMarae> GetAllMarae()
        {
            return maraeProvider.GetAllMarae();
        }
    }
}