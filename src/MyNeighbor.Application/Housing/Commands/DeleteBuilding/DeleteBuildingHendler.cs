using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNeighbor.Application.Common;
using MyNeighbor.Application.Common.Exceptions;
using MyNeighbor.Application.Common.Interfaces;

namespace MyNeighbor.Application.Housing.Commands.DeleteBuilding
{
    public class AddApartmentHandler(IApplicationDbContext context) : IRequestHandler<DeleteBuildingCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await context.Buildings
                .Include(b => b.Apartments)
                .FirstOrDefaultAsync(b => b.Id == request.BuildingId, cancellationToken);

            if (building == null)
            {
                return Result<Unit>.Failure("Building not found.");
            }

            context.Buildings.Remove(building);

            await context.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Success(Unit.Value);
        }
    }

}
