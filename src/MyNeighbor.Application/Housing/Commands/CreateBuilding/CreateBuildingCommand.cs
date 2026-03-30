using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MyNeighbor.Application.Common;

namespace MyNeighbor.Application.Housing.Commands.CreateBuilding
{
    public record CreateBuildingCommand(string Name, string City, string Street, string HouseNumber) : IRequest<Result<Guid>>;
}
