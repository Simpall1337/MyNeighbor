using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MyNeighbor.Application.Housing.Commands.CreateBuilding
{
    public record CreateBuildingCommand(string Name, string City, string Street, string HouseNumber) : IRequest<Guid>;
}
