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
    public class NgaTangataController : ControllerBase
    {
        private readonly ILogger<Marae> _logger;
        private ITangataService tangataService;

        private IMapper tangataMapper;

        public NgaTangataController(ILogger<Marae> logger, ITangataService service, IMapper mapper)
        {
            _logger = logger;
            tangataService = service;

            tangataMapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string orderby, string searchString, bool includeMarae, bool includeChildren)
        {
            //ToDo: Improve this action
            var ngaTangata = await tangataService.GetAllTangataAsync(orderby, searchString, includeMarae, includeChildren);

            if (includeMarae && !includeChildren)
            {
                return Ok(tangataMapper.Map<IEnumerable<Tangata>, IEnumerable<TangataResourceWithNgaMarae>>(ngaTangata));
            }
            else if (!includeMarae && includeChildren)
            {
                return Ok(tangataMapper.Map<IEnumerable<Tangata>, IEnumerable<TangataResourceWithChildren>>(ngaTangata));
            }
            else if (includeMarae && includeChildren)
            {
                return Ok(tangataMapper.Map<IEnumerable<Tangata>, IEnumerable<TangataResourceWithNgaMaraeChildren>>(ngaTangata));
            }
            else
            {
                var resources = tangataMapper.Map<IEnumerable<Tangata>, IEnumerable<TangataResource>>(ngaTangata);
                return Ok(resources);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, bool includeMarae, bool includeChildren)
        {
            var ngaTangata = await tangataService.GetTangataByIdAsync(id, includeMarae, includeChildren);

            if (includeMarae && !includeChildren)
            {
                return Ok(tangataMapper.Map<Tangata, TangataResourceWithNgaMarae>(ngaTangata));
            }
            else if (!includeMarae && includeChildren)
            {
                return Ok(tangataMapper.Map<Tangata, TangataResourceWithChildren>(ngaTangata));
            }
            else if (includeMarae && includeChildren)
            {
                return Ok(tangataMapper.Map<Tangata, TangataResourceWithNgaMaraeChildren>(ngaTangata));
            }
            else
            {
                var resources = tangataMapper.Map<Tangata, TangataResource>(ngaTangata);
                return Ok(resources);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateTangataAsync([FromBody] SaveTangataResource newTangata)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tangata = tangataMapper.Map<SaveTangataResource, Tangata>(newTangata);
            var marae = newTangata.NgaMaraeIdList;

            //ToDo: Investigate how many to many relationships work
            var result = await tangataService.CreateTangataAsync(tangata, marae);

            if (!result.Success)
                return BadRequest(result.Message);

            var tangataResource = tangataMapper.Map<Tangata, TangataResource>(result.Tangata);
            return Created(nameof(GetByIdAsync), tangataResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTangataAsync(int id, [FromBody] SaveTangataResource editTangata)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tangata = tangataMapper.Map<SaveTangataResource, Tangata>(editTangata);
            var marae = editTangata.NgaMaraeIdList;

            var result = await tangataService.UpdateTangataAsync(id, tangata, marae);

            var updatedTangata = tangataMapper.Map<Tangata, TangataResourceWithNgaMaraeChildren>(result.Tangata);

            return Ok(updatedTangata);
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
            return Created(nameof(GetByIdAsync), tangata);
        }
    }
}