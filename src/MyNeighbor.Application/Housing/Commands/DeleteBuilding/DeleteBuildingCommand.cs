using MediatR;
using MyNeighbor.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeighbor.Application.Housing.Commands.DeleteBuilding
{
    public record DeleteBuildingCommand(Guid BuildingId) : IRequest<Result<Unit>>;
}
