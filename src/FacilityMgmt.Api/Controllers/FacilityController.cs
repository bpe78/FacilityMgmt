using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FacilityMgmt.Api.Contracts;
using FacilityMgmt.DAL.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FacilityMgmt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public FacilityController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var models = await tx.Facilities.GetAll(0);
                    var dtos = models.Select(_mapper.Map<FacilityDto>).ToArray();
                    return new JsonResult(dtos);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<FacilityDto>>> GetAllInGroup(int groupId)
        {
            if (groupId <= 0)
                return BadRequest();

            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var models = await tx.Facilities.GetAll(groupId);
                    var dtos = models.Select(_mapper.Map<FacilityDto>).ToArray();
                    return new JsonResult(dtos);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacilityDto>> Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var model = await tx.Facilities.Get(id);
                    return new JsonResult(_mapper.Map<FacilityDto>(model));
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Forbid();
        }
    }
}
