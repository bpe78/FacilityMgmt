using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FacilityMgmt.Api.Contracts;
using FacilityMgmt.DAL.Common.Interfaces;
using FacilityMgmt.DAL.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FacilityMgmt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityGroupController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public FacilityGroupController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [SwaggerOperation("GetAllFacilityGroups")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<FacilityGroupDto>>> GetAll()
        {
            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var models = await tx.FacilityGroups.GetAll();
                    var dtos = models.Select(_mapper.Map<FacilityGroupDto>).ToArray();

                    return new JsonResult(dtos);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation("GetFacilityGroupById")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<FacilityGroupDto>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var model = await tx.FacilityGroups.Get(id);
                    return new JsonResult(_mapper.Map<FacilityGroupDto>(model));
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [SwaggerOperation("CreateFacilityGroup")]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Post([FromBody] FacilityGroupDto dto)
        {
            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var model = _mapper.Map<FacilityGroup>(dto);
                    var id = await tx.FacilityGroups.Create(model);
                    model.Id = id;
                    return CreatedAtAction(nameof(GetById), new { id }, model);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation("UpdateFacilityGroup")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Put(int id, [FromBody] FacilityGroupDto dto)
        {
            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var model = _mapper.Map<FacilityGroup>(dto);
                    var result = await tx.FacilityGroups.Update(model);
                    if (result)
                        return Ok();
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteFacilityGroup")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var result = await tx.FacilityGroups.Delete(id);
                    if (result)
                        return Ok();
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
