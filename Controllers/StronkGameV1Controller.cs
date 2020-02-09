using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stronkgame.Commands;
using stronkgame.Models;
using stronkgame.Queries;

namespace stronkgame.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class StronkGameV1Controller : ControllerBase
    {
        private readonly ILogger<StronkGameV1Controller> _logger;
        private readonly IMediator _mediator;

        public StronkGameV1Controller(
            ILogger<StronkGameV1Controller> logger,
            IMediator mediator
        )
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all placements in JSON format.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/placement/json
        ///
        /// </remarks>
        [HttpGet("placement/json")]
        [Produces("application/json")]
        public async Task<GetPlacementsAsJsonResponse> GetPlacementsAsJson()
        {
            var mediatorResponse = await _mediator.Send(new GetPlacementsRequest());
            var mediatorResponses = mediatorResponse.Placements.Select(p => new PlacementResponse()
            {
                ColorCode = p.ColorCode,
                XPosition = p.XPosition,
                YPosition = p.YPosition
            });

            return new GetPlacementsAsJsonResponse(mediatorResponses);
        }

        /// <summary>
        /// Add or replace a placement.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/placement
        ///     {
        ///        "colorCode": "#FF0000,
        ///        "xPosition": 69,
        ///        "yPosition": 420
        ///     }
        ///
        /// </remarks>
        [HttpPost("placement")]
        [Produces("application/json")]
        public async Task<AddPlacementResponse> AddPlacement([FromBody] AddPlacementBody body)
        {
            var mediatorResponse = await _mediator.Send(
                new AddPlacementRequest(
                    body.ColorCode,
                    body.XPosition,
                    body.YPosition
                )
            );

            return mediatorResponse;
        }
    }
}
