using MediatR;
using MyNeighbor.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyNeighbor.Application.Housing.Commands.AddApartment
{
    public class AddApartmentHandler(IApplicationDbContext context) : IRequestHandler<AddApartmentCommand>
    {
        public async Task Handle(AddApartmentCommand request, CancellationToken cancellationToken)
        {
            var building = await context.Buildings
                .Include(b => b.Apartments)
                .FirstOrDefaultAsync(b => b.Id == request.BuildingId, cancellationToken)
                ?? throw new InvalidOperationException($"Building {request.BuildingId} not found");

            building.AddApartment(request.Number, request.Floor);

            var newApartment = building.Apartments.Last();
            context.Apartments.Add(newApartment);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
