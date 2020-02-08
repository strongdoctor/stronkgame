using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace stronkgame.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1")]
    public class StronkGameV1Controller : ControllerBase
    {
        private readonly ILogger<StronkGameV1Controller> _logger;

        public StronkGameV1Controller(ILogger<StronkGameV1Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Content("{\"test\":\"Test\"}", "application/json");
        }
    }
}
