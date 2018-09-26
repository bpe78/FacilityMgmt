using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FacilityMgmt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityGroupController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "value1", "value2" };
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
