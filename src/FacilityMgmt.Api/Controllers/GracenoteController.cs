using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FacilityMgmt.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FacilityMgmt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GracenoteController : ControllerBase
    {
        private readonly IGracenoteConnector _connector;
        private readonly Serilog.ILogger _logger;

        public GracenoteController(IGracenoteConnector connector, Serilog.ILogger logger)
        {
            _connector = connector ?? throw new ArgumentNullException(nameof(connector));
            _logger = logger.ForContext<GracenoteController>();
        }

        [HttpGet]
        [Route("ipg-categories/{level:int}")]
        public async Task<IActionResult> GetIpgCategories(int level)
        {
            var categoryId = string.Empty;
            switch (level)
            {
                case 1: categoryId = "IPGCATEGORY_L1"; break;
                case 2: categoryId = "IPGCATEGORY_L2"; break;
                default: return BadRequest();
            }

            try
            {
                var categories = await _connector.GetIpgCategories(categoryId);
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
