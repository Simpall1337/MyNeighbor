using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MyNeighbor.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyNeighbor.Application.Housing.Queries.GetBuildings
{
    public class GetBuildingsHandler(IApplicationDbContext context) : IRequestHandler<GetBuildingsQuery, List<BuildingDto>>
    {
        public async Task<List<BuildingDto>> Handle(GetBuildingsQuery request, CancellationToken cancellationToken)
        {
            return await context.Buildings
                .Select(b => new BuildingDto(
                    b.Id,
                    b.Name,
                    b.Address.City,
                    b.Address.Street,
                    b.Address.HouseNumber))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
