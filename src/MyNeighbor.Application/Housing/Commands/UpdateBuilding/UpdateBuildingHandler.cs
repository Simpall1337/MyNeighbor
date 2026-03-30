using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNeighbor.Application.Common;
using MyNeighbor.Application.Common.Exceptions;
using MyNeighbor.Application.Common.Interfaces;
using MyNeighbor.Domain.Housing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeighbor.Application.Housing.Commands.UpdateBuilding
{
    public class UpdateBuildingHandler(IApplicationDbContext context) : IRequestHandler<UpdateBuildingCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await context.Buildings
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (building == null)
            {
                return Result<Unit>.Failure($"Building {request.Id} not found");
            }

            var address = new Address(request.City, request.Street, request.HouseNumber);

            building.Update(request.Name, address);

            await context.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
