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
        public async Task<ActionResult<IEnumerable<FacilityGroupDto>>> GetAll()
        {
            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var models = await tx.FacilityGroups.GetAll();
                    var dtos = models.Select(_mapper.Map<FacilityGroupDto>);

                    return new JsonResult(dtos);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacilityGroupDto>> Get(int id)
        {
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
        public async Task<ActionResult> Post([FromBody] FacilityGroupDto dto)
        {
            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var model = _mapper.Map<FacilityGroup>(dto);
                    var result = await tx.FacilityGroups.Create(model);
                    //return Created();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacilityGroupDto dto)
        {
            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var model = _mapper.Map<FacilityGroup>(dto);
                    var result = await tx.FacilityGroups.Update(model);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Forbid();
        }
    }
}
