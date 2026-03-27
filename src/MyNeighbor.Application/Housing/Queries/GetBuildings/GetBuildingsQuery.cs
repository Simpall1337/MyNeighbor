using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MyNeighbor.Application.Housing.Queries.GetBuildings
{
    public record GetBuildingsQuery : IRequest<List<BuildingDto>>;
    public record BuildingDto(Guid Id, string Name, string City, string Street, string HouseNumber);
}
