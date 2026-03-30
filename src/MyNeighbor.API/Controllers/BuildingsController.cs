using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNeighbor.API.Contracts.Housing;
using MyNeighbor.Application.Common;
using MyNeighbor.Application.Housing.Commands.AddApartment;
using MyNeighbor.Application.Housing.Commands.CreateBuilding;
using MyNeighbor.Application.Housing.Commands.DeleteBuilding;
using MyNeighbor.Application.Housing.Commands.UpdateBuilding;
using MyNeighbor.Application.Housing.Queries.GetBuildingById;
using MyNeighbor.Application.Housing.Queries.GetBuildings;

namespace MyNeighbor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetBuildingsQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{buildingId}")]
        public async Task<IActionResult> GetById(Guid buildingId, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetBuildingByIdQuery(buildingId), cancellationToken);
            if (!result.IsSuccess)
                return NotFound(result.Error); 

            return Ok(result.Value); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBuildingCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            if (!result.IsSuccess)
                return NotFound(result.Error);

            return CreatedAtAction(nameof(GetById), new { result.Value }, result.Value);
        }

        [HttpPost("{buildingId}/apartments")]
        public async Task<IActionResult> AddApartment(Guid buildingId, [FromBody] AddApartmentRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new AddApartmentCommand(buildingId, request.Number, request.Floor), cancellationToken);
            
            if (!result.IsSuccess)
                return NotFound(result.Error);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteBuildingCommand(id), cancellationToken);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateBuildingRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new UpdateBuildingCommand(
                id,
                request.Name,
                request.City,
                request.Street,
                request.HouseNumber), cancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(result.Error);
            }

            return NoContent();
        }
    }
}
