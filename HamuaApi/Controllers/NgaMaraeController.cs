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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<NgaMarae> _logger;
        private IMaraeProvider orderProvider;

        public NgaMaraeController(ILogger<NgaMarae> logger, IMaraeProvider provider)
        {
            _logger = logger;
            orderProvider = provider;
        }

        [HttpGet]
        public IEnumerable<NgaMarae> Get()
        {
            var orders = orderProvider.GetAllOrders().ToList();
            return orders;
        }
    }
}