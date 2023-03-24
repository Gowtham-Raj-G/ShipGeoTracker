using Microsoft.AspNetCore.Mvc;
using ShipGeoTracker.Api.Infrastructure.Models;
using ShipGeoTracker.Api.Services.Interfaces;

namespace ShipGeoTracker.Api.Controllers
{
    [Route("api/ships")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly IShipService shipService;
        private readonly ILogger<ShipController> logger;

        public ShipController(IShipService shipService, ILogger<ShipController> logger)
        {
            this.shipService = shipService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await shipService.GetAllAsync());
            }
            catch (Exception ex)
            {
                // log the error and return an error response
                logger.LogError($"Failed to get all ships: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ShipRequestModel shipRequestModel)
        {
            if (shipRequestModel == null)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await shipService.AddAsync(shipRequestModel));
            }
            catch (Exception ex)
            {
                // log the error and return an error response
                logger.LogError($"Failed to add ship: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ShipUpdateRequestModel shipUpdateRequestModel)
        {
            if (shipUpdateRequestModel == null)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await shipService.UpdateAsync(id, shipUpdateRequestModel));
            }
            catch (Exception ex)
            {
                // log the error and return an error response
                logger.LogError($"Failed to update ship: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}/closest-port")]
        public async Task<IActionResult> GetClosestPort(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                var closestPort = await shipService.GetClosestPortAsync(id);

                if (closestPort == null)
                {
                    return NotFound();
                }

                return Ok(closestPort);
            }
            catch (Exception ex)
            {
                // log the error and return an error response
                logger.LogError($"Failed to get closest port: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
