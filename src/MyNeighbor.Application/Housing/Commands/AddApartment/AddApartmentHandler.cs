using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNeighbor.Application.Common;
using MyNeighbor.Application.Common.Exceptions;
using MyNeighbor.Application.Common.Interfaces;

namespace MyNeighbor.Application.Housing.Commands.AddApartment
{
    public class AddApartmentHandler(IApplicationDbContext context) : IRequestHandler<AddApartmentCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(AddApartmentCommand request, CancellationToken cancellationToken)
        {
            var building = await context.Buildings
                .Include(b => b.Apartments)
                .FirstOrDefaultAsync(b => b.Id == request.BuildingId, cancellationToken);

            if (building == null)
                return Result<Unit>.Failure($"Building {request.BuildingId} not found");

            try
            {
                building.AddApartment(request.Number, request.Floor);

                var newApartment = building.Apartments.Last();
                context.Apartments.Add(newApartment);

                await context.SaveChangesAsync(cancellationToken);

                return Result<Unit>.Success(Unit.Value);
            }
            catch (Exception ex)
            {
                return Result<Unit>.Failure(ex.Message);
            }
        }
    }
}
