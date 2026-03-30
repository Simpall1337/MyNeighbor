using MediatR;
using MyNeighbor.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeighbor.Application.Housing.Commands.UpdateBuilding
{
    public record UpdateBuildingCommand(Guid Id, string Name, string City, string Street, string HouseNumber) : IRequest<Result<Unit>>;
}
