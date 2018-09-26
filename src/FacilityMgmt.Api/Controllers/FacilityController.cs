using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public FacilityController(IDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacilityDto>>> GetAll()
        {
            try
            {
                using (var tx = _dataService.BeginTransaction())
                {
                    var result = await tx.Facilities.GetAll();
                    return new JsonResult(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
